using System.Threading.Tasks;

namespace NCrafts.App.Business.Common.Infrastructure
{
    public delegate Task NavigateToSessionDetails(SessionId sessionId);
    public delegate Task NavigateToSpeakerDetails(SpeakerId speakerId);

    public delegate Task MenuOpenTabbedDaily();
    public delegate Task MenuOpenSessions();
    public delegate Task MenuOpenSpeakers();
    public delegate Task MenuOpenAbout();
}
