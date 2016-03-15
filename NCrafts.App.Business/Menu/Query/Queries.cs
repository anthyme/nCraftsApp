using System.Collections.Generic;
using NCrafts.App.Business.Menu.Command;

namespace NCrafts.App.Business.Menu.Query
{
    public delegate ICollection<MenuItem> GetMenuItemsQuery();

    class Queries
    {
        public static GetMenuItemsQuery CreateGetMenuItemsQuery(OpenDailyCommand openDailyCommand,
                                                                OpenSessionsCommand openSessionsCommand,
                                                                OpenSpeakersCommand openSpeakersCommand,
                                                                OpenLocationCommand openLocationCommand,
                                                                OpenAboutCommand openAboutCommand)
        {
            return () => new List<MenuItem>
            {
                new MenuItem {Title = "Daily", OpenCommand = () => openDailyCommand(), Icon = "dailyicon.png"},
                new MenuItem {Title = "Sessions", OpenCommand = () => openSessionsCommand(), Icon = "sessionsicon.png"},
                new MenuItem {Title = "Speakers", OpenCommand = () => openSpeakersCommand(), Icon = "speakersicon.png"},
                new MenuItem {Title = "Location", OpenCommand = () => openLocationCommand(), Icon = "mapicon.png"},
                new MenuItem {Title = "About", OpenCommand = () => openAboutCommand(), Icon = "abouticon.png"},
            };
        }
    }
}