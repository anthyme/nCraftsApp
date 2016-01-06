using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ObjectBuilder2;
using NCrafts.App.Core.Common;

namespace NCrafts.App.Core.Sessions.Query
{
    public delegate ICollection<SessionSummary> GetSessionSumariesQuery();
    public delegate SessionDetails GetSessionDetailsQuery(SessionId sessionId);
    public delegate string GetSessionSpearkersNameQuery(SessionId sessionId);
    public delegate string GetSessionTagTitleQuery(SessionId sessionId);

    public class Queries
    {
        public static GetSessionSpearkersNameQuery CreateGetSessionSpearkersNameQuery(IDataSourceRepository dataSourceRepository)
        {
            return sessionId =>
                dataSourceRepository.Retreive().Sessions
                    .Single(x => x.Id.Equals(sessionId))
                    .Speakers.JoinStrings("\n", speaker => speaker.FirstName + " " + speaker.LastName);
        }

        public static GetSessionTagTitleQuery CreateGetSessionTagTitleQuery(IDataSourceRepository dataSourceRepository)
        {
            return sessionId =>
                dataSourceRepository.Retreive().Sessions
                    .Single(x => x.Id.Equals(sessionId))
                    .Tags.JoinStrings(", ", tag => tag.Title);
        }

        public static GetSessionSumariesQuery CreateGetSessionSumariesQuery(IDataSourceRepository dataSourceRepository)
        {
            return () => dataSourceRepository.Retreive().Sessions
                            .Select(x => new SessionSummary { Id = x.Id, Title = x.Title })
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
                    Interval = x.Interval,
                    Room = x.Room,
                    Tags = x.Tags,
                    Description = x.Description
                })
                .First();
        }
    }
}
