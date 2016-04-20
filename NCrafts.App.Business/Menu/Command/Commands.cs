using System.Threading.Tasks;
using NCrafts.App.Business.Common.Infrastructure;

namespace NCrafts.App.Business.Menu.Command
{
    public delegate Task OpenSessionsCommand();
    public delegate Task OpenPersonalScheduleCommand();
    public delegate Task OpenSpeakersCommand();
    public delegate Task OpenLocationCommand();
    public delegate Task OpenAboutCommand();
    public delegate Task ReturnHomeCommand();

    class Commands
    {
        public static OpenSessionsCommand CreateOpenSessionsCommand(NavigateToSessionsFromMenu navigateToSessionsFromMenu)
        {
            return () => navigateToSessionsFromMenu();
        }

        public static OpenPersonalScheduleCommand CreateOpenPersonalScheduleCommand(NavigateToPersonalScheduleFromMenu navigateToPersonalScheduleFromMenu)
        {
            return () => navigateToPersonalScheduleFromMenu();
        }

        public static OpenSpeakersCommand CreateOpenSpeakersCommand(NavigateToSpeakersFromMenu navigateToSpeakersFromMenu)
        {
            return () => navigateToSpeakersFromMenu();
        }

        public static OpenLocationCommand CreateOpenLocationCommand(NavigateToLocationFromMenu navigateToLocationFromMenu)
        {
            return () => navigateToLocationFromMenu();
        }

        public static OpenAboutCommand CreateOpenAboutCommand(NavigateToAboutFromMenu navigateToAboutFromMenu)
        {
            return () => navigateToAboutFromMenu();
        }

        public static ReturnHomeCommand CreateReturnHomeCommand(NavigateToHomeFromAbout navigateToHomeFromAbout)
        {
            return () => navigateToHomeFromAbout();
        }
    }
}