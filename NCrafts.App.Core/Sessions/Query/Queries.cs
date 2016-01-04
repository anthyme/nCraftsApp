using System.Collections.Generic;
using System.Linq;
using NCrafts.App.Core.Common;

namespace NCrafts.App.Core.Sessions.Query
{
    public delegate ICollection<SessionSummary> GetSessionSumariesQuery();
    public delegate SessionDetails GetSessionDetailsQuery(SessionId sessionId);

    public class Queries
    {
        public static GetSessionSumariesQuery CreateGetSessionSumariesQuery(DataSource dataSource)
        {
            return () => dataSource.Sessions.Select(x => new SessionSummary { Id = x.Id, Title = x.Title }).ToList();
        }

        public static GetSessionDetailsQuery CreateGetSessionDetailsQuery(DataSource dataSource)
        {
            return sessionId =>
                dataSource.Sessions
                .Where(x => x.Id.Equals(sessionId))
                .Select(x => new SessionDetails
                {
                    Id = x.Id,
                    Title = x.Title,
                    Speakers = x.Speakers,
                    Interval = x.Interval,
                    Room = x.Room,
                    Tags = x.Tags,
                    Description = x.Description
                })
                .First();
        }
    }
}
