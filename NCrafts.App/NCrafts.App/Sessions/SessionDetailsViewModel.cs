using System.Threading.Tasks;
using NCrafts.App.Common.Infrastructure;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Sessions.Query;

namespace NCrafts.App.Sessions
{
    public class SessionDetailsViewModel : ViewModelBase
    {
        private readonly GetSessionDetailsQuery getSessionDetailsQuery;
        private readonly GetSessionSpearkersNameQuery getSessionSpearkersNameQuery;
        private readonly GetSessionTagTitleQuery getSessionTagTitleQuery;

        private SessionId sessionId;
        private SessionDetails session;
        private string speakers;
        private string tags;

        public SessionDetailsViewModel(GetSessionDetailsQuery getSessionDetailsQuery, GetSessionSpearkersNameQuery getSessionSpearkersNameQuery, GetSessionTagTitleQuery getSessionTagTitleQuery)
        {
            this.getSessionDetailsQuery = getSessionDetailsQuery;
            this.getSessionSpearkersNameQuery = getSessionSpearkersNameQuery;
            this.getSessionTagTitleQuery = getSessionTagTitleQuery;
        }

        public SessionDetails Session
        {
            get { return session; }
            set { session = value; OnPropertyChanged(); }
        }

        public string Speakers
        {
            get { return speakers; }
            set { speakers = value; OnPropertyChanged(); }
        }

        public string Tags
        {
            get { return tags; }
            set { tags = value; OnPropertyChanged(); }
        }

        public void Init(SessionId sessionId) //todo: put sessionId initialization in ctor if possible with the IoC
        {
            this.sessionId = sessionId;
        }

        protected override Task OnStart()
        {
            Session = getSessionDetailsQuery(sessionId);
            Speakers = getSessionSpearkersNameQuery(sessionId);
            Tags = getSessionTagTitleQuery(sessionId);
            return Task.FromResult(0);
        }
    }
}
