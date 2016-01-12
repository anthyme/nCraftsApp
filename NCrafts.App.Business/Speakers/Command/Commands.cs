using System.Threading.Tasks;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Common.Infrastructure;

namespace NCrafts.App.Business.Speakers.Command
{
    public delegate Task OpenSpeakerCommand(SpeakerId speakerId);

    class Commands
    {
        public static OpenSpeakerCommand CreateOpenSpeakerCommand(NavigateToSpeakerDetails navigateToSpeakerDetails)
        {
            return speakerId => navigateToSpeakerDetails(speakerId);
        }
    }
}