using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        // TODO: check to use observalbe collection or the IList because nroamlly IList is more optimized
        //private ObservableCollection<SpeakerSummary> speakers;
        private IList<SpeakerSummary> spearkers; 

        public SpeakersViewModel(OpenSpeakerCommand openSpeakerCommand, GetSpeakerSumariesQuery getSpeakerSumariesQuery)
        {
            OpenSpeakerCommand = new Command<SpeakerId>(x => openSpeakerCommand(x));
            this.getSpeakerSumariesQuery = getSpeakerSumariesQuery;
        }

        public ICommand OpenSpeakerCommand { get; }

        public IList<SpeakerSummary> Speakers
        {
            get { return spearkers;}
            set { spearkers = value; OnPropertyChanged(); }
        }

        //public ObservableCollection<SpeakerSummary> Speakers
        //{
        //    get { return speakers;}
        //    set { speakers = value; OnPropertyChanged(); }
        //}

        protected override Task OnStart()
        {
            //Speakers = new ObservableCollection<SpeakerSummary>(getSpeakerSumariesQuery());
            Speakers = getSpeakerSumariesQuery().ToList();
            return Task.FromResult(0);
        }
    }
}