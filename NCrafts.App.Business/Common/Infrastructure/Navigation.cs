using System.Threading.Tasks;

namespace NCrafts.App.Business.Common.Infrastructure
{
    public delegate Task NavigateToMenuFromMenu();
    public delegate Task NavigateToSessionsFromMenu();
    public delegate Task NavigateToSpeakersFromMenu();
    public delegate Task NavigateToAboutFromMenu();
    public delegate Task NavigateToSessionDetails(SessionId sessionId);
    public delegate Task NavigateToSpeakerDetails(SpeakerId speakerId);

    public delegate Task NavigateToTabbedDaily();
}
