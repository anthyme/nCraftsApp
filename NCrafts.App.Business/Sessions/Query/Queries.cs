﻿using System;
using System.Collections.Generic;
using System.Linq;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Common.Infrastructure.Fx;
using NCrafts.App.Business.Core.Data;

namespace NCrafts.App.Business.Sessions.Query
{
    public delegate ICollection<SessionSummary> GetSessionSumariesQuery();
    public delegate SessionCalendar GetSessionCalendarQuery(SessionId sessionsId);
    public delegate ICollection<Tuple<SessionSummary, bool>> GetSessionSumariesSubscribQuery();
    public delegate ICollection<Grouping<string, SessionSummary>> GetSessionSumariesQuery2();
    public delegate ICollection<SessionSummary> GetSessionSumariesSpeakerQuery(List<SessionId> sessionsId);
    public delegate SessionDetails GetSessionDetailsQuery(SessionId sessionId);

    public delegate List<int> GetDaysNumberQuery();

    class Queries
    {
        // TODO: I didn't know where i should put this method so right now I left it there.
        // TODO: Check also if the data will be formatted on this pattern
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
                                Date = x.Interval.StartDate == DateTime.MinValue ? "Day not defined yet" : "Day " + GetDay(dataSourceRepository.Retreive().OpeningTime, x.Interval.StartDate) + ": " + x.Interval.StartDate.ToString("t") + " - " + x.Interval.EndDate.ToString("t"),
                            })
                            .ToList();
        }

        public static GetSessionCalendarQuery CreateGetSessionCalendarQuery(IDataSourceRepository dataSourceRepository)
        {
            return sessionsId => dataSourceRepository.Retreive().Sessions
                    .Where(session => session.Id.Equals(sessionsId))
                    .Select(x => new SessionCalendar
                    {
                        Id = x.Id.ToString(),
                        Title = x.Title,
                        Description = x.Description,
                        Date = x.Interval
                    }).First();
        }

        // TODO: check the problem come from the query
        public static GetSessionSumariesSubscribQuery CreateGetSessionSumariesSubscribQuery(IDataSourceRepository dataSourceRepository)
        {
            return () =>
            {
                return dataSourceRepository.Retreive().Sessions
                    .Where(session => session.IsRegister)
                    .Select(x => new Tuple<SessionSummary, bool>(new SessionSummary
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Date = x.Interval.StartDate == DateTime.MinValue ? "Day not defined yet" :
                            "Day " + GetDay(dataSourceRepository.Retreive().OpeningTime, x.Interval.StartDate) + ": " +
                            x.Interval.StartDate.ToString("t") + " - " + x.Interval.EndDate.ToString("t"),
                    },
                        x.SessionsConflit.Count > 0))
                    .ToList();
            };
        }

        // TODO: wait for implementation
        public static GetSessionSumariesQuery2 CreateGetSessionSumariesQuery2(IDataSourceRepository dataSourceRepository)
        {
            return () =>
            {
                var test = dataSourceRepository.Retreive().Sessions
                    .OrderBy(x => x.Interval.StartDate)
                    .GroupBy(x => string.Format(x.Interval.StartDate == DateTime.MinValue ? "Day not defined yet" : "Day: {0:dd}/{0:MM} at {0:hhtt}", x.Interval.StartDate))
                    .Select(
                        days =>
                            new Grouping<string, SessionSummary>(days.Key, days.ToList().Select(x => new SessionSummary
                            {
                                Id = x.Id,
                                Title = x.Title,
                                Date = x.Interval.StartDate == DateTime.MinValue ? "Day not defined yet" :
                                    "Day " + GetDay(dataSourceRepository.Retreive().OpeningTime, x.Interval.StartDate) +
                                    ": " + x.Interval.StartDate.ToString("t") + " - " + x.Interval.EndDate.ToString("t"),
                            }))).ToList();
                return test;
            };
        }

        public static GetSessionSumariesSpeakerQuery CreateGetSessionSumariesSpeakerQuery(IDataSourceRepository dataSourceRepository)
        {
            return sessionsId => dataSourceRepository.Retreive().Sessions
                            .Where(x => sessionsId.Contains(x.Id))
                            .Select(x => new SessionSummary
                            {
                                Id = x.Id,
                                Title = x.Title,
                                Date = x.Interval.StartDate == DateTime.MinValue ? "Day not defined yet" : "Day " + GetDay(dataSourceRepository.Retreive().OpeningTime, x.Interval.StartDate) + ": " + x.Interval.StartDate.ToString("t") + " - " + x.Interval.EndDate.ToString("t"),
                            })
                            .ToList();
        }

        public static GetDaysNumberQuery CreateGetDaysNumberQuery(IDataSourceRepository dataSourceRepository)
        {
            return () => dataSourceRepository.Retreive()
                        .Sessions.GroupBy(session => session.Interval.StartDate.DayOfYear)
                        .Select(x => x.Key).ToList();
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
                    Date = x.Interval.StartDate == DateTime.MinValue ? "Day not defined yet" : "Day " + GetDay(dataSourceRepository.Retreive().OpeningTime, x.Interval.StartDate) + ": " + x.Interval.StartDate.ToString("t") + " - " + x.Interval.EndDate.ToString("t"),
                    Room = x.Room.Name,
                    Tags = string.Join(", ", x.Tags.Select(t => t.Title)),
                    Description = x.Description,
                    IsRegister = x.IsRegister,
                    SpeakersId = x.Speakers
                })
                .First();
        }
    }
}
