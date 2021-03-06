﻿using System;
using System.Collections.Generic;
using System.Linq;
using NCrafts.App.Business.Common.JsonSerializer.Data;
using NCrafts.App.Business.Common.Network;
using NCrafts.App.Business.Core;

namespace NCrafts.App.Business.Common.JsonSerializer
{
    public class Converter
    {
        public static Conf GetConfFromJson(string json)
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfModel>(json);
            return new Conf { Version = result.Version, SessionsUrl = result.Urls.Sessions, SpeakersUrl = result.Urls.Speakers };
        }

        public static Tuple<List<Session>, List<Tag>> GetSessionsAndTagsFromJson(string json)
        {
            var objectResult = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SessionModel>>(json);
            var sessions = objectResult.Select(
                session =>
                    new Session
                    {
                        Id = new SessionId(session.Id),
                        Title = session.Title,
                        Description = session.Details,
                        Interval = string.IsNullOrWhiteSpace(session.StartTime) ? new TimeSlot { EndDate = DateTime.MinValue, StartDate = DateTime.MinValue } : new TimeSlot { StartDate = Convert.ToDateTime(session.StartTime), EndDate = Convert.ToDateTime(session.StartTime).AddMinutes(session.DurationInMinutes) },
                        Room = new Room { Name = string.IsNullOrWhiteSpace(session.Place) ? "Room not defined yet" : session.Place },
                        IsRegister = false,
                        SessionsConflit = new List<Session>(),
                        Tags = new List<Tag>(),
                        Speakers = session.SpeakersId.Select(speakerId => new SpeakerId(speakerId)).ToList(),
                    }).ToList();
            var tags = objectResult.SelectMany(session =>
                session.Tags.Select(tag => new Tag { Title = tag, Sessions = new List<SessionId> { new SessionId(session.Id) } }))
                .GroupBy(tag => tag.Title).Select(group => new Tag { Title = group.Key, Sessions = new List<SessionId>(group.SelectMany(x => x.Sessions).ToList()) })
                .ToList();

            foreach (var tag in tags)
            {
                foreach (var tagListSession in
                    tag.Sessions.SelectMany(sessionId => sessions, (sessionId, session) => new { sessionId, session })
                        .Where(tuple => tuple.session.Id.ToString() == tuple.sessionId.ToString())
                        .Select(tagsList => tagsList.session.Tags))
                {
                    tagListSession.Add(tag);
                }
            }
            return new Tuple<List<Session>, List<Tag>>(sessions, tags);
        }

        public static List<Speaker> GetSpeakersFromJson(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<SpeakerModel>>(json)
                .Select(speaker => new Speaker
                {
                    FirstName = speaker.FirstName,
                    LastName = speaker.LastName,
                    Details = speaker.Details,
                    Id = new SpeakerId(speaker.Id),
                    ProfilPicture = speaker.Avatar.IconBig,
                    ProfilPictureIcon = speaker.Avatar.IconSmall,
                    Sessions = speaker.SessionsId.Select(session => new SessionId(session)).ToList(),
                    Company = speaker.Company,
                    Twitter = speaker.Twitter,
                    Github = speaker.Github,
                    Site = speaker.Site,
                }).ToList();
        }
    }
}
