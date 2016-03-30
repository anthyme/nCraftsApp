using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Sessions.Command;
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
        private readonly SessionId id;
        private SessionDetails session;
        private double heightList;
        private ObservableCollection<SpeakerSummary> speakers;
        private string sharedText = "I'm going to see ";

        public SessionDetailsViewModel(OpenSpeakerCommand openSpeakerCommand,
                                       ShareSessionCommand shareSessionCommand,
                                       GetSessionDetailsQuery getSessionDetailsQuery,
                                       GetSpeakersSumariesSessionQuery getSpeakersSumariesSessionQuery,
                                       SessionId id)
        {
            this.id = id;
            OpenSpeakerCommand = new Command<SpeakerId>(x => openSpeakerCommand(x));
            ShareSessionCommand = new Command(() => shareSessionCommand(sharedText));
            this.getSessionDetailsQuery = getSessionDetailsQuery;
            this.getSpeakersSumariesSessionQuery = getSpeakersSumariesSessionQuery;
        }

        public ICommand OpenSpeakerCommand { get; }

        public ICommand ShareSessionCommand { get; }

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

        protected override Task OnStart()
        {
            Session = getSessionDetailsQuery(id);
            Speakers = new ObservableCollection<SpeakerSummary>(getSpeakersSumariesSessionQuery(session.SpeakersId));
            sharedText += ($"{string.Join(", " , speakers.Select(x => string.IsNullOrWhiteSpace(x.Twitter) ? x.Name : x.Twitter).ToList())} speaking about {session.Title}! #NCrafts");
            HeightList = speakers.Count * 85;
            return Task.FromResult(0);
        }
    }
}
