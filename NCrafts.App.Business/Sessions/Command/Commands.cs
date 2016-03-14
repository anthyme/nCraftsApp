using System.Threading.Tasks;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Common.Infrastructure;

namespace NCrafts.App.Business.Sessions.Command
{
    public delegate Task OpenSessionCommand(SessionId sessionId);

    class Commands
    {
        public static OpenSessionCommand CreateOpenSessionCommand(NavigateToSessionDetails navigateToSessionDetails)
        {
            return sessionId => navigateToSessionDetails(sessionId);
        }
    }
}
