using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using NCrafts.App.About;
using NCrafts.App.Business.Common.Infrastructure;
using NCrafts.App.Sessions;
using NCrafts.App.Speakers;
using NCrafts.App.Business.Common.Infrastructure.Fx;
using NCrafts.App.Location;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public delegate Task NavigateToView(IViewViewModel viewViewModel);
    public delegate Task NavigateToViewFromMenu(IViewViewModel viewViewModel);
    public delegate void SetMenuVisibility(bool isVisible);
    public delegate void SetTabbedCurrentPage(string title);

    public class Navigation
    {
        public static NavigateToView CreateNavigateToView(NavigationPage navigationPage)
        {
            return async vvm =>
            {
                var startTask = vvm.ViewModel.Start();
                await navigationPage.PushAsync(vvm.View, true);
                await startTask;
            };
        }

        public static NavigateToViewFromMenu CreateNavigateToViewFromMenu(NavigationPage navigationPage)
        {
            return async vvm =>
            {
                var startTask = vvm.ViewModel.Start();

                await navigationPage.PushAsync(vvm.View, true);
                navigationPage.Navigation.NavigationStack
                    .Skip(1)
                    .Take(navigationPage.Navigation.NavigationStack.Count - 2)
                    .ToList()
                    .ForEach(navigationPage.Navigation.RemovePage);
                await startTask;
            };
        }

        public static NavigateToSessionsFromMenu CreateNavigateToSessionsFromMenu(HandleErrorAsync handleErrorAsync, SetMenuVisibility setMenuVisibility, NavigationPage navigationPage)
        {
            return () => handleErrorAsync(async () =>
            {
                setMenuVisibility(false);
                await navigationPage.PopToRootAsync();
            });
        }

        public static NavigateToHomeFromAbout CreateNavigateToHomeFromAbout(HandleErrorAsync handleErrorAsync, SetMenuVisibility setMenuVisibility, NavigationPage navigationPage)
        {
            return () => handleErrorAsync(async () =>
            {
                await navigationPage.PopAsync();
            });
        }

        public static NavigateToAboutFromMenu CreateNavigateToAboutFromMenu(HandleErrorAsync handleErrorAsync,
            NavigateToView navigateToView, IViewFactory viewFactory, SetMenuVisibility setMenuVisibility, NavigationPage navigationPage)
        {
            return () => handleErrorAsync(async () =>
            {
                if (HandleNavigationFromMenu(typeof (AboutView), navigationPage, setMenuVisibility))
                {
                    await navigateToView(viewFactory.Create<AboutView, AboutViewModel>());
                }
            });
        }

        public static NavigateToPersonalScheduleFromMenu CreateNavigateToPersonalScheduleFromMenu(HandleErrorAsync handleErrorAsync,
            NavigateToViewFromMenu navigateToViewFromMenu, IViewFactory viewFactory, SetMenuVisibility setMenuVisibility, NavigationPage navigationPage)
        {
            return () => handleErrorAsync(async () =>
            {
                if (HandleNavigationFromMenu(typeof(PersonalScheduleView), navigationPage, setMenuVisibility))
                    await navigateToViewFromMenu(viewFactory.Create<PersonalScheduleView, PersonalScheduleViewModel>());
            });
        }

        public static NavigateToSpeakersFromMenu CreateNavigateToSpeakersFromMenu(HandleErrorAsync handleErrorAsync,
            NavigateToViewFromMenu navigateToViewFromMenu, IViewFactory viewFactory, SetMenuVisibility setMenuVisibility, NavigationPage navigationPage)
        {
            return () => handleErrorAsync(async () =>
            {
                if (HandleNavigationFromMenu(typeof(SpeakersView), navigationPage, setMenuVisibility))
                    await navigateToViewFromMenu(viewFactory.Create<SpeakersView, SpeakersViewModel>());
            });
        }

        public static NavigateToLocationFromMenu CreateNavigateToLocationFromMenu(HandleErrorAsync handleErrorAsync,
            NavigateToViewFromMenu navigateToViewFromMenu, IViewFactory viewFactory, SetMenuVisibility setMenuVisibility, NavigationPage navigationPage)
        {
            return () => handleErrorAsync(async () =>
            {
                if (HandleNavigationFromMenu(typeof(LocationView), navigationPage, setMenuVisibility))
                    await navigateToViewFromMenu(viewFactory.Create<LocationView, LocationViewModel>());
            });
        }

        private static bool HandleNavigationFromMenu(Type viewType, NavigationPage navigationPage, SetMenuVisibility setMenuVisibility)
        {
            setMenuVisibility(false);
            return navigationPage.CurrentPage.GetType() != viewType;
        }

        public static NavigateToSessionDetails CreateNavigateToSessionDetails(HandleErrorAsync handleErrorAsync,
            NavigateToView navigateToView, IViewFactory viewFactory)
        {
            return sessionId => handleErrorAsync(() => navigateToView(viewFactory.Create<SessionDetailsView, SessionDetailsViewModel>(new ParameterOverride("id", sessionId))));
        }

        public static NavigateToSpeakerDetails CreateNavigateToSpeakerDetails(HandleErrorAsync handleErrorAsync,
            NavigateToView navigateToView, IViewFactory viewFactory)
        {
            return speakerId => handleErrorAsync(() => navigateToView(viewFactory.Create<SpeakerDetailsView, SpeakerDetailsViewModel>(new ParameterOverride("id", speakerId))));
        }
    }
}
