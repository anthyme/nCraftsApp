using System.Threading.Tasks;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Common.Infrastructure;
using Plugin.Share;

namespace NCrafts.App.Business.Sessions.Command
{
    public delegate Task OpenSessionCommand(SessionId sessionId);
    public delegate Task ShareSessionCommand(string text);

    class Commands
    {
        public static OpenSessionCommand CreateOpenSessionCommand(NavigateToSessionDetails navigateToSessionDetails)
        {
            return sessionId => navigateToSessionDetails(sessionId);
        }

        public static ShareSessionCommand CreateShareSessionCommand()
        {
            return text => CrossShare.Current.Share(text);
        }
    }
}
