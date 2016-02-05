using System.Threading.Tasks;

namespace NCrafts.App.Business.Common.Infrastructure
{
    public delegate Task NavigateToHome();
    public delegate Task NavigateToMenu();

    public delegate Task NavigateToSessions();
    public delegate Task NavigateToSessionDetails(SessionId sessionId);
    public delegate Task NavigateToSpeakers();
    public delegate Task NavigateToSpeakerDetails(SpeakerId speakerId);

    public delegate Task MenuOpenSessions();
    public delegate Task MenuOpenSpeakers();
    public delegate Task MenuOpenTabbedDaily();
}
