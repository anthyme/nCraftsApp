using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using NCrafts.App.Business.Common.Calendar;
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
        private readonly GetSessionCalendarQuery getSessionCalendarQuery;
        private readonly SessionId id;
        private SessionDetails session;
        private double heightList;
        private ObservableCollection<SpeakerSummary> speakers;
        private string sharedText = "I'm going to see ";
        private string buttonValue;

        public SessionDetailsViewModel(OpenSpeakerCommand openSpeakerCommand,
                                       SubscribeSessionCommand subscribeSessionCommand,
                                       UnSubscribeSessionCommand unSubscribeSessionCommand,
                                       ShareSessionCommand shareSessionCommand,
                                       GetSessionDetailsQuery getSessionDetailsQuery,
                                       GetSpeakersSumariesSessionQuery getSpeakersSumariesSessionQuery,
                                       GetSessionCalendarQuery getSessionCalendarQuery,
                                       SessionId id,
                                       ICalendar calendar)
        {
            this.id = id;
            OpenSpeakerCommand = new Command<SpeakerId>(x => openSpeakerCommand(x));
            ShareSessionCommand = new Command(() => shareSessionCommand(sharedText));
            this.getSessionDetailsQuery = getSessionDetailsQuery;
            this.getSessionCalendarQuery = getSessionCalendarQuery;
            OnClickSubscribeCommand = new Command(() =>
            {
                if (session.IsRegister)
                {
                    calendar.DeleteSessionInCalendar(this.getSessionCalendarQuery(id));
                    unSubscribeSessionCommand(id);
                    Session = getSessionDetailsQuery(id);
                    ButtonValue = session.IsRegister ? "Unsubscribe" : "Subscribe";
                }
                else
                {
                    calendar.SetSessionInCalendar(this.getSessionCalendarQuery(id));
                    subscribeSessionCommand(id);
                    Session = getSessionDetailsQuery(id);
                    ButtonValue = session.IsRegister ? "Unsubscribe" : "Subscribe";
                }
            });
            this.getSpeakersSumariesSessionQuery = getSpeakersSumariesSessionQuery;
        }

        public ICommand OpenSpeakerCommand { get; }

        public ICommand ShareSessionCommand { get; }

        public ICommand OnClickSubscribeCommand { get; }

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

        public string ButtonValue
        {
            get { return buttonValue; }
            set { buttonValue = value; OnPropertyChanged(); }
        }

        protected override Task OnStart()
        {
            Session = getSessionDetailsQuery(id);
            Speakers = new ObservableCollection<SpeakerSummary>(getSpeakersSumariesSessionQuery(session.SpeakersId));
            sharedText += ($"{string.Join(", " , speakers.Select(x => string.IsNullOrWhiteSpace(x.Twitter) ? x.Name : x.Twitter).ToList())} speaking about {session.Title}! #NCrafts");
            ButtonValue = session.IsRegister ? "Unsubscribe" : "Subscribe";
            HeightList = speakers.Count * 85;
            return Task.FromResult(0);
        }
    }
}
