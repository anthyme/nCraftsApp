using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NCrafts.App.Business.Common.Infrastructure;

namespace NCrafts.App.Business.Menu.Command
{
    public delegate Task OpenMenuItemCommand(string id);

    class Commands
    {
        public static OpenMenuItemCommand CreateOpenMenuItemCommand(
            NavigateToMenuFromMenu navigateToMenuFromMenu, NavigateToSessionsFromMenu navigateToSessionsFromMenu,
            NavigateToSpeakersFromMenu navigateToSpeakersFromMenu, NavigateToAboutFromMenu navigateToAboutFromMenu)
        {
            var menuTask = new Dictionary<string, Delegate>
            {
                { "0", navigateToMenuFromMenu },
                { "1", navigateToSessionsFromMenu },
                { "2", navigateToSpeakersFromMenu },
                { "3", navigateToAboutFromMenu }
            };
            return (id) => (Task)menuTask[id].DynamicInvoke();
        }
    }
}