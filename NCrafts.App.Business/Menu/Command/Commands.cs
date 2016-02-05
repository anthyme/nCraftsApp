using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NCrafts.App.Business.Common.Infrastructure;

namespace NCrafts.App.Business.Menu.Command
{
    public delegate Task OpenMenuItemCommand(string id);

    class Commands
    {
        public static OpenMenuItemCommand CreateOpenMenuItemCommand(MenuOpenTabbedDaily menuOpenTabbedDaily, MenuOpenSessions menuOpenSessions, MenuOpenSpeakers menuOpenSpeakers)
        {
            var menuTask = new Dictionary<string, Delegate>
            {
                { "0", menuOpenTabbedDaily },
                { "1", menuOpenSessions },
                { "2", menuOpenSpeakers }
            };
            return (id) => (Task)menuTask[id].DynamicInvoke();
        }
    }
}