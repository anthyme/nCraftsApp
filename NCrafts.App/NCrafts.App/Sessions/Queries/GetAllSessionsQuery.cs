using System.Collections.Generic;
using System.Linq;
using NCrafts.App.Common;
using NCrafts.App.Common.Infrastructure.Fx;

namespace NCrafts.App.Sessions.Queries
{
    public class GetAllSessionsQuery : IQueryMany<Session>
    {
        private readonly DataSource dataSource;

        public GetAllSessionsQuery(DataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public ICollection<Session> Execute()
        {
            return dataSource.Sessions.ToList();
        }  
    }
}