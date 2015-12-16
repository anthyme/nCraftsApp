using System.Linq;
using NCrafts.App.Common;
using NCrafts.App.Common.Infrastructure.Fx;

namespace NCrafts.App.Sessions.Queries
{
    public class GetSessionByIdQuery : IQuery<int, Session>
    {
        private readonly DataSource dataSource;

        public GetSessionByIdQuery(DataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public Session Execute(int sessionId)
        {
            return dataSource.Sessions.First(x => x.Id == sessionId);
        }
    }
}
