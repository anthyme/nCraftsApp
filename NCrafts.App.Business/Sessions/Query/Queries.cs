using System;
using System.Collections.Generic;
using System.Linq;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Core.Data;

namespace NCrafts.App.Business.Sessions.Query
{
    public delegate ICollection<SessionSummary> GetSessionSumariesQuery();
    public delegate SessionDetails GetSessionDetailsQuery(SessionId sessionId);

    class Queries
    {
        // I didn't know where i should put this method so right now I left it there.
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

        public static GetSessionDetailsQuery CreateGetSessionDetailsQuery(IDataSourceRepository dataSourceRepository)
        {
            return sessionId =>
                dataSourceRepository.Retreive().Sessions
                .Where(x => x.Id.Equals(sessionId))
                .Select(x => new SessionDetails
                {
                    Id = x.Id,
                    Title = x.Title,
                    Speakers = string.Join("\n", x.Speakers.Select(s => s.FirstName + " " + s.LastName)),
                    Date = "Day " + GetDay(dataSourceRepository.Retreive().OpeningTime, x.Interval.StartDate) + ": " + x.Interval.StartDate.ToString("t") + " - " + x.Interval.EndDate.ToString("t"),
                    Room = x.Room.Name,
                    Tags = string.Join(", ", x.Tags.Select(t => t.Title)),
                    Description = x.Description,
                })
                .First();
        }
    }
}
