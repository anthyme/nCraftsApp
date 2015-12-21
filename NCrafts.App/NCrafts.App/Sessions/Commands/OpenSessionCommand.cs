using NCrafts.App.Common.Infrastructure;
using NCrafts.App.Common.Infrastructure.Fx;

namespace NCrafts.App.Sessions.Commands
{
    public class OpenSessionCommand : CommandBase<int>
    {
        private readonly INavigateTo navigateTo;

        public OpenSessionCommand(INavigateTo navigateTo)
        {
            this.navigateTo = navigateTo;
        }

        public override void Execute(int sessionId)
        {
            navigateTo.Session(sessionId);
        }
    }
}
