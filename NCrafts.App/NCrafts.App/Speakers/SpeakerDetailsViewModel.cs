using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Sessions.Command;
using NCrafts.App.Business.Sessions.Query;
using NCrafts.App.Business.Speakers.Command;
using NCrafts.App.Business.Speakers.Query;
using NCrafts.App.Common.Infrastructure;
using Xamarin.Forms;

namespace NCrafts.App.Speakers
{
    public class SpeakerDetailsViewModel : ViewModelBase
    {
        private readonly GetSpeakerDetailsQuery getSpeakerDetailsQuery;
        private readonly GetSessionSumariesSpeakerQuery getSessionSumariesSpeakerQuery;
        private readonly SpeakerId id;
        private SpeakerDetails speaker;
        private double heightList;
        private ObservableCollection<SessionSummary> sessions;

        private bool isStackLayoutEnable;
        private bool isLabelTwitterEnable;
        private bool isLabelSeparatorTCEnable;
        private bool isLabelCompanyEnable;
        private bool isLabelSeparatorCGEnable;
        private bool isLabelGithubEnable;

        public SpeakerDetailsViewModel(OpenSessionCommand openSessionCommand,
                                       OpenUrlCommand openUrlCommand,
                                       GetSpeakerDetailsQuery getSpeakerDetailsQuery,
                                       GetSessionSumariesSpeakerQuery getSessionSumariesSpeakerQuery,
                                       SpeakerId id)
        {
            this.id = id;
            this.getSpeakerDetailsQuery = getSpeakerDetailsQuery;
            this.getSessionSumariesSpeakerQuery = getSessionSumariesSpeakerQuery;
            heightList = 0;
            OpenSessionCommand = new Command<SessionId>(x => openSessionCommand(x));
            OpenUrlCommand = new Command<string>(x => openUrlCommand(x));
        }

        public ICommand OpenSessionCommand { get; }

        public ICommand OpenUrlCommand { get; }

        public SpeakerDetails Speaker
        {
            get { return speaker; }
            set { speaker = value; OnPropertyChanged(); }
        }

        // TODO: find a proper solution, Don't use binding!!
        public double HeightList
        {
            get { return heightList; }
            set { heightList = value; OnPropertyChanged(); }
        }

        public ObservableCollection<SessionSummary> Sessions
        {
            get { return sessions; }
            set { sessions = value; OnPropertyChanged(); }
        }

        public bool IsStackLayoutEnable
        {
            get { return isStackLayoutEnable; }
            set { isStackLayoutEnable = value; OnPropertyChanged(); }
        }

        public bool IsLabelTwitterEnable
        {
            get { return isLabelTwitterEnable; }
            set { isLabelTwitterEnable = value; OnPropertyChanged(); }
        }

        public bool IsLabelSeparatorTCEnable
        {
            get { return isLabelSeparatorTCEnable; }
            set { isLabelSeparatorTCEnable = value; OnPropertyChanged(); }
        }

        public bool IsLabelCompanyEnable
        {
            get { return isLabelCompanyEnable; }
            set { isLabelCompanyEnable = value; OnPropertyChanged(); }
        }

        public bool IsLabelSeparatorCGEnable
        {
            get { return isLabelSeparatorCGEnable; }
            set { isLabelSeparatorCGEnable = value; OnPropertyChanged(); }
        }

        public bool IsLabelGithubEnable
        {
            get { return isLabelGithubEnable; }
            set { isLabelGithubEnable = value; OnPropertyChanged(); }
        }

        protected override Task OnStart()
        {
            Speaker = getSpeakerDetailsQuery(id);

            IsLabelTwitterEnable = !string.IsNullOrWhiteSpace(Speaker.Twitter);
            IsLabelCompanyEnable = !string.IsNullOrWhiteSpace(Speaker.Company);
            IsLabelGithubEnable = !string.IsNullOrWhiteSpace(Speaker.Github);
            IsLabelSeparatorTCEnable = isLabelTwitterEnable && (isLabelCompanyEnable || isLabelGithubEnable);
            IsLabelSeparatorCGEnable = isLabelCompanyEnable && isLabelGithubEnable;
            IsStackLayoutEnable = isLabelTwitterEnable || isLabelCompanyEnable || isLabelGithubEnable;

            Sessions = new ObservableCollection<SessionSummary>(getSessionSumariesSpeakerQuery(Speaker.SessionsId));
            HeightList = sessions.Count * 52;
            return Task.FromResult(0);
        }
    }
}