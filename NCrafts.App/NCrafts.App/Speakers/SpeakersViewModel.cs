using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NCrafts.App.Business.Speakers.Query;
using NCrafts.App.Common.Infrastructure;

namespace NCrafts.App.Speakers
{
    public class SpeakersViewModel : ViewModelBase
    {
        private readonly GetSpeakerSumariesQuery getSpeakerSumariesQuery;
        private ObservableCollection<SpeakerSummary> speakers;
        private string header;

        public SpeakersViewModel(GetSpeakerSumariesQuery getSpeakerSumariesQuery)
        {
            this.getSpeakerSumariesQuery = getSpeakerSumariesQuery;
        }

        public ObservableCollection<SpeakerSummary> Speakers
        {
            get { return speakers;}
            set { speakers = value; OnPropertyChanged(); }
        }

        public string Header
        {
            get { return header; }
            set { header = value; OnPropertyChanged(); }
        }


        protected override Task OnStart()
        {
            Speakers = new ObservableCollection<SpeakerSummary>(getSpeakerSumariesQuery());
            Header = Resx.AppResources.SpeakersHeader;
            return Task.FromResult(0);
        }
    }
}