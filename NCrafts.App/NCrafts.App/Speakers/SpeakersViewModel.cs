using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Speakers.Command;
using NCrafts.App.Business.Speakers.Query;
using NCrafts.App.Common.Infrastructure;
using Xamarin.Forms;

namespace NCrafts.App.Speakers
{
    public class SpeakersViewModel : ViewModelBase
    {
        private readonly GetSpeakerSumariesQuery getSpeakerSumariesQuery;
        private ObservableCollection<SpeakerSummary> speakers;

        public ICommand OpenSpeakerCommand { get; }

        public SpeakersViewModel(OpenSpeakerCommand openSpeakerCommand, GetSpeakerSumariesQuery getSpeakerSumariesQuery)
        {
            OpenSpeakerCommand = new Command<SpeakerId>(x => openSpeakerCommand(x));
            this.getSpeakerSumariesQuery = getSpeakerSumariesQuery;
        }

        public ObservableCollection<SpeakerSummary> Speakers
        {
            get { return speakers;}
            set { speakers = value; OnPropertyChanged(); }
        }

        protected override Task OnStart()
        {
            Speakers = new ObservableCollection<SpeakerSummary>(getSpeakerSumariesQuery());
            return Task.FromResult(0);
        }
    }
}