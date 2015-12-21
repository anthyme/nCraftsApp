using System.Threading.Tasks;
using NCrafts.App.Common.Infrastructure;
using NCrafts.App.Core.Common;
using NCrafts.App.Core.Sessions.Query;

namespace NCrafts.App.Sessions
{
    public class SessionDetailsViewModel : ViewModelBase
    {
        private readonly GetSessionDetailsQuery getSessionDetailsQuery;

        private SessionId sessionId;
        private SessionDetails session;

        public SessionDetailsViewModel(GetSessionDetailsQuery getSessionDetailsQuery)
        {
            this.getSessionDetailsQuery = getSessionDetailsQuery;
        }

        public SessionDetails Session
        {
            get { return session; }
            set { session = value; OnPropertyChanged(); }
        }

        public void Init(SessionId sessionId) //todo: put sessionId initialization in ctor if possible with the IoC
        {
            this.sessionId = sessionId;
        }

        protected override Task OnStart()
        {
            Session = getSessionDetailsQuery(sessionId);
            return Task.FromResult(0);
        }
    }
}
