using System.Threading.Tasks;
using NCrafts.App.Common;
using NCrafts.App.Common.Infrastructure.Fx;

namespace NCrafts.App.Sessions
{
    public class SessionDetailsViewModel : ViewModelBase
    {
        private readonly IQuery<int, Session> getSessionById;
        private int sessionId;
        private Session session;

        public SessionDetailsViewModel(IQuery<int, Session> getSessionById)
        {
            this.getSessionById = getSessionById;
        }

        public void Init(int sessionId) //todo: put sessionId initialization in ctor if possible with the IoC
        {
            this.sessionId = sessionId;
        }

        public override Task Start()
        {
            Session = getSessionById.Execute(sessionId);
            return base.Start();
        }

        public Session Session
        {
            get { return session; }
            set { session = value; OnPropertyChanged(); }
        }
    }
}
