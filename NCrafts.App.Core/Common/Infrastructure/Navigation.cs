using System.Threading.Tasks;

namespace NCrafts.App.Core.Common.Infrastructure
{
    public delegate Task NavigateToSessions();
    public delegate Task NavigateToSessionDetails(SessionId sessionId);
}
