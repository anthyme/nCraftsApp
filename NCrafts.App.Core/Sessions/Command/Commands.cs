using System.Threading.Tasks;
using NCrafts.App.Core.Common;
using NCrafts.App.Core.Common.Infrastructure;

namespace NCrafts.App.Core.Sessions.Command
{
    public delegate Task OpenSessionCommand(SessionId sessionId);

    public class Commands
    {
        public static OpenSessionCommand CreateOpenSessionCommand(NavigateToSessionDetails navigateToSessionDetails)
        {
            return sessionId => navigateToSessionDetails(sessionId);
        }
    }
}
