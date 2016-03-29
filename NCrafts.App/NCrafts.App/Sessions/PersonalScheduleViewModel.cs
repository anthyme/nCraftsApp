using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Sessions.Command;
using NCrafts.App.Business.Sessions.Query;
using NCrafts.App.Common.Infrastructure;
using Xamarin.Forms;

namespace NCrafts.App.Sessions
{
    public class PersonalScheduleViewModel : ViewModelBase
    {
        private readonly GetSessionSumariesSubscribQuery getSessionSumariesSubscribQuery;
        private ObservableCollection<Tuple<SessionSummary, Color>> sessions;

        public PersonalScheduleViewModel(OpenSessionCommand openSessionCommand, GetSessionSumariesSubscribQuery getSessionSumariesSubscribQuery)
        {
            this.getSessionSumariesSubscribQuery = getSessionSumariesSubscribQuery;
            OpenSessionCommand = new Command<SessionId>(x => openSessionCommand(x));
        }

        public ICommand OpenSessionCommand { get; }

        public ObservableCollection<Tuple<SessionSummary, Color>> Sessions
        {
            get { return sessions; }
            set
            {
                sessions = value;
                OnPropertyChanged();
            }
        }

        // TODO: Check how to manage conflict trouble, color code or waht ever.
        protected override Task OnStart()
        {
            Sessions = new ObservableCollection<Tuple<SessionSummary, Color>>(getSessionSumariesSubscribQuery().Select(x => new Tuple<SessionSummary, Color>(x.Item1, Color.FromHex(x.Item2 ? "#F75050" : "#FFFFFF"))));
            return Task.FromResult(0);
        }
    }
}