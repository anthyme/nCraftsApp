using System.Linq;
using System.Threading.Tasks;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Common.Infrastructure;
using NCrafts.App.Business.Core.Data;
using Plugin.Share;

namespace NCrafts.App.Business.Sessions.Command
{
    public delegate Task OpenSessionCommand(SessionId sessionId);
    public delegate void SubscribeSessionCommand(SessionId sessionId);
    public delegate void UnSubscribeSessionCommand(SessionId sessionId);
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

        public static SubscribeSessionCommand CreateSubscribenSessionCommand(IDataSourceRepository dataSourceRepository)
        {
            return sessionId => dataSourceRepository.Retreive().Sessions.Single(x => x.Id.ToString() == sessionId.ToString()).Register(dataSourceRepository.Retreive().Sessions.Where(x => x.IsRegister).ToList());
        }

        public static UnSubscribeSessionCommand CreateUnSubscribeSessionCommand(IDataSourceRepository dataSourceRepository)
        {
            return sessionId => dataSourceRepository.Retreive().Sessions.Single(x => x.Id.ToString() == sessionId.ToString()).UnRegister();
        }
    }
}
