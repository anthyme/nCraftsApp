using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Sessions.Command;
using NCrafts.App.Business.Sessions.Query;
using NCrafts.App.Common.Infrastructure;
using Xamarin.Forms;

namespace NCrafts.App.Sessions
{
    public class DailySessionViewModel : ViewModelBase
    {
        private readonly GetSessionSumariesByDayQuery getSessionSumariesByDayQuery;
        private ObservableCollection<SessionSummary> sessions;
        private string title;

        public DailySessionViewModel(int day, string title, OpenSessionCommand openSessionCommand, GetSessionSumariesByDayQuery getSessionSumariesByDayQuery)
        {
            Day = day;
            this.title = title;
            this.getSessionSumariesByDayQuery = getSessionSumariesByDayQuery;
            OpenSessionCommand = new Command<SessionId>(x => openSessionCommand(x));
        }

        public int Day { get; }

        public ICommand OpenSessionCommand { get; }

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        public ObservableCollection<SessionSummary> Sessions
        {
            get { return sessions; }
            set { sessions = value; OnPropertyChanged(); }
        }

        protected override Task OnStart()
        {
            Sessions = new ObservableCollection<SessionSummary>(getSessionSumariesByDayQuery(Day));
            return Task.FromResult(0);
        }
    }
}