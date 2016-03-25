using System;
using System.Threading.Tasks;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Common.Infrastructure;
using Xamarin.Forms;

namespace NCrafts.App.Business.Speakers.Command
{
    public delegate Task OpenSpeakerCommand(SpeakerId speakerId);
    public delegate void OpenUrlCommand(string url);

    class Commands
    {
        public static OpenSpeakerCommand CreateOpenSpeakerCommand(NavigateToSpeakerDetails navigateToSpeakerDetails)
        {
            return speakerId => navigateToSpeakerDetails(speakerId);
        }

        public static OpenUrlCommand CreateOpenUrlCommand()
        {
            return url => Device.OpenUri(new Uri("http://twitter.com/" + (url.StartsWith("@") ? url.Substring(1) : url)));
        }
    }
}