using NCrafts.App.Core.Common;
using NCrafts.App.Core.Common.Infrastructure;

namespace NCrafts.App.Core.Sessions.Command
{
    public delegate void OpenSessionCommand(SessionId sessionId);

    public class Commands
    {
        public static OpenSessionCommand CreateOpenSessionCommand(INavigateTo navigateTo)
        {
            return sessionId => navigateTo.Session(sessionId);
        }
    }
}
