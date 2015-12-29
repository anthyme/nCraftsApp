using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using NCrafts.App.Common.Infrastructure;
using NCrafts.App.Core.Common;
using NCrafts.App.Core.Sessions.Command;
using NCrafts.App.Core.Sessions.Query;
using Xamarin.Forms;

namespace NCrafts.App.Sessions
{
    public class SessionsViewModel : ViewModelBase
    {
        private readonly GetSessionSumariesQuery getSessionSumariesQuery;
        private ObservableCollection<SessionSummary> sessions;
        private string header;

        public SessionsViewModel(
            OpenSessionCommand openSessionCommand,
            GetSessionSumariesQuery getSessionSumariesQuery)
        {
            this.getSessionSumariesQuery = getSessionSumariesQuery;
            OpenSessionCommand = new Command<SessionId>(x => openSessionCommand(x));
        }

        public ICommand OpenSessionCommand { get; }

        public string Header
        {
            get { return header; }
            set { header = value; OnPropertyChanged(); }
        }

        public ObservableCollection<SessionSummary> Sessions
        {
            get { return sessions; }
            set { sessions = value; OnPropertyChanged(); }
        }

        protected override Task OnStart()
        {
            getSessionSumariesQuery().Subscribe(x => { Sessions = new ObservableCollection<SessionSummary>(x); });
            Header = "Sessions";
            return Task.FromResult(0);
        }
    }
}
