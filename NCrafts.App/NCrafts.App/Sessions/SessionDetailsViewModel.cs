using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Sessions.Query;
using NCrafts.App.Business.Speakers.Command;
using NCrafts.App.Business.Speakers.Query;
using NCrafts.App.Common.Infrastructure;
using Xamarin.Forms;

namespace NCrafts.App.Sessions
{
    public class SessionDetailsViewModel : ViewModelBase
    {
        private readonly GetSessionDetailsQuery getSessionDetailsQuery;
        private readonly GetSpeakersSumariesSessionQuery getSpeakersSumariesSessionQuery;
        private SessionId sessionId;
        private SessionDetails session;
        private double heightList;
        private ObservableCollection<SpeakerSummary> speakers;

        public ICommand OpenSpeakerCommand { get; }

        public SessionDetailsViewModel(OpenSpeakerCommand openSpeakerCommand,
                                       GetSessionDetailsQuery getSessionDetailsQuery,
                                       GetSpeakersSumariesSessionQuery getSpeakersSumariesSessionQuery)
        {
            OpenSpeakerCommand = new Command<SpeakerId>(x => openSpeakerCommand(x));
            this.getSessionDetailsQuery = getSessionDetailsQuery;
            this.getSpeakersSumariesSessionQuery = getSpeakersSumariesSessionQuery;
        }

        public SessionDetails Session
        {
            get { return session; }
            set { session = value; OnPropertyChanged(); }
        }

        // TODO: find a proper solution, Don't use binding!!
        public double HeightList
        {
            get { return heightList; }
            set { heightList = value; OnPropertyChanged(); }
        }

        public ObservableCollection<SpeakerSummary> Speakers
        {
            get { return speakers; }
            set { speakers = value; OnPropertyChanged(); }
        }

        public void Init(SessionId sessionId) //todo: put sessionId initialization in ctor if possible with the IoC
        {
            this.sessionId = sessionId;
        }

        protected override Task OnStart()
        {
            Session = getSessionDetailsQuery(sessionId);
            Speakers = new ObservableCollection<SpeakerSummary>(getSpeakersSumariesSessionQuery(session.SpeakersId));
            HeightList = speakers.Count * 52;
            return Task.FromResult(0);
        }
    }
}
