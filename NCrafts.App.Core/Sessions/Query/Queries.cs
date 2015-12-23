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


        //public SessionId Id { get; set; }
        //public string Title { get; set; }
        //public List<Speaker> Speakers { get; set; }
        //public string Room { get; set; }
        //public DateTime DateStart { get; set; }
        //public DateTime DateEnd { get; set; }
        //public List<Tag> Tags { get; set; }
        //public string Description { get; set; }


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
                    DateStart = x.DateStart,
                    DateEnd = x.DateEnd,
                    Room = x.Room,
                    Tags = x.Tags,
                    Description = x.Description
                })
                .First();
        }
    }
}
