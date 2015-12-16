using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NCrafts.App.Common;
using NCrafts.App.Common.Infrastructure.Fx;

namespace NCrafts.App.Sessions
{
    public class SessionsViewModel : ViewModelBase
    {
        private readonly IQueryMany<Session> getAllSessions;
        private ObservableCollection<Session> sessions;
        private string header;

        public SessionsViewModel(ICommand selectSessionCommand, IQueryMany<Session> getAllSessions)
        {
            this.getAllSessions = getAllSessions;
            SelectSessionCommand = selectSessionCommand;
        }

        public ICommand SelectSessionCommand { get; }

        public string Header
        {
            get { return header; }
            set { header = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Session> Sessions
        {
            get { return sessions; }
            set { sessions = value; OnPropertyChanged(); }
        }

        public override Task Start()
        {
            Sessions = new ObservableCollection<Session>(getAllSessions.Execute());
            Header = "Sessions";
            return Task.FromResult(0);
        }
    }
}
