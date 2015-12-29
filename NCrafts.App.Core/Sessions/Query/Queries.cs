using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using NCrafts.App.Common.Events;
using NCrafts.App.Core.Common;
using ReactiveUI;

namespace NCrafts.App.Core.Sessions.Query
{
    public delegate IObservable<ICollection<SessionSummary>> GetSessionSumariesQuery();
    public delegate SessionDetails GetSessionDetailsQuery(SessionId sessionId);

    public class Queries
    {
        public static GetSessionSumariesQuery CreateGetSessionSumariesQuery(IDataSourceRepository dataSourceRepository, IMessageBus messageBus)
        {
            Func<ICollection<SessionSummary>> getSessionSumaries = 
                () => dataSourceRepository.Retreive().Sessions
                        .Select(x => new SessionSummary { Id = x.Id, Title = x.Title })
                        .ToList();
            return () => messageBus.Listen<DataSourceUpdated>().Select(ev => getSessionSumaries());
        }

        public static GetSessionDetailsQuery CreateGetSessionDetailsQuery(IDataSourceRepository dataSourceRepository)
        {
            return sessionId =>
                dataSourceRepository.Retreive().Sessions
                    .Where(x => x.Id.Equals(sessionId))
                    .Select(x => new SessionDetails { Id = x.Id, Title = x.Title })
                    .First();
        }
    }
}
