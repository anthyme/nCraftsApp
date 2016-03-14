using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NCrafts.App.Common.Infrastructure;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Sessions.Command;
using NCrafts.App.Business.Sessions.Query;
using Xamarin.Forms;

namespace NCrafts.App.Sessions
{
    public class SessionsViewModel : ViewModelBase
    {
        private readonly GetSessionSumariesQuery getSessionSumariesQuery;
        private ObservableCollection<SessionSummary> sessions;

        public SessionsViewModel(OpenSessionCommand openSessionCommand, GetSessionSumariesQuery getSessionSumariesQuery)
        {
            this.getSessionSumariesQuery = getSessionSumariesQuery;
            OpenSessionCommand = new Command<SessionId>(x => openSessionCommand(x));
        }

        public ICommand OpenSessionCommand { get; }

        public ObservableCollection<SessionSummary> Sessions
        {
            get { return sessions; }
            set { sessions = value; OnPropertyChanged(); }
        }

        protected override Task OnStart()
        {
            Sessions = new ObservableCollection<SessionSummary>(getSessionSumariesQuery());
            return Task.FromResult(0);
        }
    }
}
