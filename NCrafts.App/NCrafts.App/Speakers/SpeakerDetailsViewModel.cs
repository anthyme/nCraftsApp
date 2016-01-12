using System.Threading.Tasks;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Speakers.Query;
using NCrafts.App.Common.Infrastructure;

namespace NCrafts.App.Speakers
{
    public class SpeakerDetailsViewModel : ViewModelBase
    {
        private readonly GetSpeakerDetailsQuery getSpeakerDetailsQuery;
        private SpeakerId id;
        private SpeakerDetails speaker;

        public SpeakerDetailsViewModel(GetSpeakerDetailsQuery getSpeakerDetailsQuery)
        {
            this.getSpeakerDetailsQuery = getSpeakerDetailsQuery;
        }

        public SpeakerDetails Speaker
        {
            get { return speaker; }
            set { speaker = value; OnPropertyChanged(); }
        }

        public void Init(SpeakerId id)
        {
            this.id = id;
        }

        protected override Task OnStart()
        {
            Speaker = getSpeakerDetailsQuery(id);
            return Task.FromResult(0);
        }
    }
}