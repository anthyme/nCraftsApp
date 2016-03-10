using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NCrafts.App.Common.Infrastructure;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Common.Infrastructure.Fx;
using NCrafts.App.Business.Sessions.Command;
using NCrafts.App.Business.Sessions.Query;
using Xamarin.Forms;

namespace NCrafts.App.Sessions
{
    public class SessionsViewModel : ViewModelBase
    {
        private readonly GetSessionSumariesQuery getSessionSumariesQuery;
        private readonly GetSessionSumariesQuery2 getSessionSumariesQuery2;
        private ObservableCollection<SessionSummary> sessions;
        private ObservableCollection<Grouping<string, SessionSummary>> sessions2;

        public SessionsViewModel(OpenSessionCommand openSessionCommand, GetSessionSumariesQuery getSessionSumariesQuery, GetSessionSumariesQuery2 getSessionSumariesQuery2)
        {
            this.getSessionSumariesQuery = getSessionSumariesQuery;
            this.getSessionSumariesQuery2 = getSessionSumariesQuery2;
            OpenSessionCommand = new Command<SessionId>(x => openSessionCommand(x));
        }

        public ICommand OpenSessionCommand { get; }

        public ObservableCollection<SessionSummary> Sessions
        {
            get { return sessions; }
            set { sessions = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Grouping<string, SessionSummary>> Sessions2
        {
            get { return sessions2; }
            set { sessions2 = value; OnPropertyChanged(); }
        }

        protected override Task OnStart()
        {
            Sessions = new ObservableCollection<SessionSummary>(getSessionSumariesQuery());
            Sessions2 = new ObservableCollection<Grouping<string, SessionSummary>>(getSessionSumariesQuery2());
            return Task.FromResult(0);
        }
    }
}
