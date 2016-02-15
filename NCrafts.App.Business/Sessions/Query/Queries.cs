﻿using System;
using System.Collections.Generic;
using System.Linq;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Core.Data;

namespace NCrafts.App.Business.Sessions.Query
{
    public delegate ICollection<SessionSummary> GetSessionSumariesQuery();
    public delegate ICollection<SessionSummary> GetSessionSumariesSpeakerQuery(List<SessionId> sessionsId);
    public delegate SessionDetails GetSessionDetailsQuery(SessionId sessionId);

    public delegate List<int> GetDaysNumberQuery();
    public delegate ICollection<SessionSummary> GetSessionSumariesByDayQuery(int day);

    class Queries
    {
        // TODO: I didn't know where i should put this method so right now I left it there.
        private static string GetDay(ICollection<TimeSlot> days, DateTime day)
        {
            int result = 1;
            foreach (var it in days)
            {
                if (it.StartDate.Day == day.Day)
                    return result.ToString();
                ++result;
            }
            return "not found";
        }

        public static GetSessionSumariesQuery CreateGetSessionSumariesQuery(IDataSourceRepository dataSourceRepository)
        {
            return () => dataSourceRepository.Retreive().Sessions
                            .Select(x => new SessionSummary
                            {
                                Id = x.Id,
                                Title = x.Title,
                                Date = "Day " + GetDay(dataSourceRepository.Retreive().OpeningTime, x.Interval.StartDate) + ": " + x.Interval.StartDate.ToString("t") + " - " + x.Interval.EndDate.ToString("t"),
                            })
                            .ToList();
        }

        public static GetSessionSumariesSpeakerQuery CreateGetSessionSumariesSpeakerQuery(IDataSourceRepository dataSourceRepository)
        {
            return sessionsId => dataSourceRepository.Retreive().Sessions
                            .Where(x => sessionsId.Contains(x.Id))
                            .Select(x => new SessionSummary
                            {
                                Id = x.Id,
                                Title = x.Title,
                                Date = "Day " + GetDay(dataSourceRepository.Retreive().OpeningTime, x.Interval.StartDate) + ": " + x.Interval.StartDate.ToString("t") + " - " + x.Interval.EndDate.ToString("t"),
                            })
                            .ToList();
        }

        public static GetDaysNumberQuery CreateGetDaysNumberQuery(IDataSourceRepository dataSourceRepository)
        {
            return () => dataSourceRepository.Retreive()
                        .Sessions.GroupBy(session => session.Interval.StartDate.DayOfYear)
                        .Select(x => x.Key).ToList();
        }

        public static GetSessionSumariesByDayQuery CreateGetSessionSumariesByDayQuery(IDataSourceRepository dataSourceRepository)
        {
            return day => dataSourceRepository.Retreive().Sessions
                        .GroupBy(session => session.Interval.StartDate.DayOfYear)
                        .Where(x => x.Key == day)
                        .Select(days => days.ToList().Select(x => new SessionSummary
                        {
                            Id = x.Id,
                            Title = x.Title,
                            Date = "Day " + GetDay(dataSourceRepository.Retreive().OpeningTime, x.Interval.StartDate) + ": " + x.Interval.StartDate.ToString("t") + " - " + x.Interval.EndDate.ToString("t"),
                        })).SelectMany(x => x).ToList();
        }

        public static GetSessionDetailsQuery CreateGetSessionDetailsQuery(IDataSourceRepository dataSourceRepository)
        {
            return sessionId =>
                dataSourceRepository.Retreive().Sessions
                .Where(x => x.Id.Equals(sessionId))
                .Select(x => new SessionDetails
                {
                    Id = x.Id,
                    Title = x.Title,
                    Date = "Day " + GetDay(dataSourceRepository.Retreive().OpeningTime, x.Interval.StartDate) + ": " + x.Interval.StartDate.ToString("t") + " - " + x.Interval.EndDate.ToString("t"),
                    Room = x.Room.Name,
                    Tags = string.Join(", ", x.Tags.Select(t => t.Title)),
                    Description = x.Description,
                    SpeakersId = x.SpeakersId
                })
                .First();
        }
    }
}
