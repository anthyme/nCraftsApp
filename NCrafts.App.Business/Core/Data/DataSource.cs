using System;
using System.Collections.Generic;
using System.Linq;
using NCrafts.App.Business.Common;

namespace NCrafts.App.Business.Core.Data
{
    public class DataSource
    {
        // TODO: check how to manage the days with NCraft, if they send me the opening hours of each day or if I should retreive it form the conferences.
        public ICollection<TimeSlot> OpeningTime { get; } = new List<TimeSlot>
        {
            new TimeSlot { StartDate = Convert.ToDateTime("2016-05-12T08:30:00.0000000+02:00"), EndDate = Convert.ToDateTime("2016-05-12T20:30:00.0000000+02:00")},
            new TimeSlot { StartDate = Convert.ToDateTime("2016-05-13T08:30:00.0000000+02:00"), EndDate = Convert.ToDateTime("2016-05-13T20:30:00.0000000+02:00")},
        };

        public ICollection<Tag> Tags { get; set; } = new List<Tag>();

        public ICollection<Speaker> Speakers { get; set; } = new List<Speaker>();

        public ICollection<Session> Sessions { get; set; } = new List<Session>();

        public DataSource()
        {
            //var speaker = Speakers.GetEnumerator();
            //var tag = Tags.GetEnumerator();
            //foreach (var session in Sessions)
            //{
            //    if (speaker.MoveNext())
            //    {
            //        session.Speakers.Add(speaker.Current.Id);
            //        speaker.Current.Sessions.Add(session.Id);
            //    }
            //    //if (int.Parse(session.Id.ToString()) % 3 == 0)
            //    //{
            //    //    session.Register(Sessions.Where(x => x.IsRegister).ToList());
            //    //}
            //    if (session.Id.ToString() == "15")
            //    {
            //        while (speaker.MoveNext())
            //        {
            //            session.Speakers.Add(speaker.Current.Id);
            //            speaker.Current.Sessions.Add(session.Id);
            //        }
            //        while (tag.MoveNext())
            //        {
            //            session.Tags.Add(tag.Current);
            //            tag.Current.Sessions.Add(session.Id);
            //        }
            //    }
            //    else if (tag.MoveNext())
            //    {
            //        session.Tags.Add(tag.Current);
            //        tag.Current.Sessions.Add(session.Id);
            //    }
            //}
        }

        // TODO: remove Union because right now the data is hard encoded after we will just have network data.
        public void AddSpeakers(ICollection<Speaker> speakers)
        {
            if (Speakers.Count == 0)
            {
                Speakers = speakers;
            }
            else
            {
                foreach (var newSpeaker in speakers)
                {
                    foreach (var oldSpeaker in Speakers)
                    {
                        if (oldSpeaker.Id.ToString() == newSpeaker.Id.ToString())
                        {
                            Speakers.Remove(oldSpeaker);
                            Speakers.Add(newSpeaker);
                            break;
                        }
                        if (oldSpeaker == Speakers.Last())
                        {
                            Speakers.Add(newSpeaker);
                            break;
                        }
                    }
                }
            }
        }

        public void AddSessions(ICollection<Session> sessions)
        {
            if (Sessions.Count == 0)
                Sessions = sessions;
            else
            {
                foreach (var newSession in sessions)
                {
                    foreach (var oldSession in Sessions)
                    {
                        if (oldSession.Id.ToString() == newSession.Id.ToString())
                        {
                            Sessions.Remove(oldSession);
                            if (oldSession.IsRegister)
                            {
                                oldSession.UnRegister();
                                newSession.Register(Sessions.Where(x => x.IsRegister).ToList());
                            }
                            Sessions.Add(newSession);
                            break;
                        }
                        if (oldSession == Sessions.Last())
                        {
                            Sessions.Add(newSession);
                            break;
                        }
                    }
                }
            }
        }

        public void AddTags(ICollection<Tag> tags)
        {
            if (Tags.Count == 0)
                Tags = tags;
            else
            {
                foreach (var newTag in tags)
                {
                    foreach (var oldTag in Tags)
                    {
                        if (oldTag.Title == newTag.Title)
                        {
                            Tags.Remove(oldTag);
                            Tags.Add(newTag);
                            break;
                        }
                        if (oldTag == Tags.Last())
                        {
                            Tags.Add(newTag);
                            break;
                        }
                    }
                }
            }
        }
    }
}
