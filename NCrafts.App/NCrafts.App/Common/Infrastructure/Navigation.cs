using System.Linq;
using System.Threading.Tasks;
using NCrafts.App.Business.Common.Infrastructure;
using NCrafts.App.Sessions;
using NCrafts.App.Speakers;
using NCrafts.App.About;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Common.Infrastructure.Fx;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public delegate Task NavigateToView(IViewViewModel viewViewModel);
    public delegate Task NavigateToViewFromMenu(IViewViewModel viewViewModel);
    public delegate void SetMenuVisibility(bool isVisible);

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

        public static NavigateToMenuFromMenu CreateNavigateToMenuFromMenu(HandleErrorAsync handleErrorAsync,
            NavigationPage navigationPage, SetMenuVisibility setMenuVisibility)
        {
            return () => handleErrorAsync(async () =>
            {
                setMenuVisibility(false);
                await navigationPage.PopToRootAsync(false);
            });
        }

        public static NavigateToSessionsFromMenu CreateNavigateToSessionsFromMenu(HandleErrorAsync handleErrorAsync,
            NavigateToViewFromMenu navigateToView, IViewFactory viewFactory, SetMenuVisibility setMenuVisibility, NavigationPage navigationPage)
        {
            return () => handleErrorAsync(async () =>
            {
                setMenuVisibility(false);
                if (navigationPage.CurrentPage.GetType() != typeof(SessionsView))
                    await navigateToView(viewFactory.Create<SessionsView, SessionsViewModel>());
            });
        }

        public static NavigateToSpeakersFromMenu CreateNavigateToSpeakersFromMenu(HandleErrorAsync handleErrorAsync,
            NavigateToViewFromMenu navigateToView, IViewFactory viewFactory, SetMenuVisibility setMenuVisibility, NavigationPage navigationPage)
        {
            return () => handleErrorAsync(async () =>
            {
                setMenuVisibility(false);
                if (navigationPage.CurrentPage.GetType() != typeof(SpeakersView))
                    await navigateToView(viewFactory.Create<SpeakersView, SpeakersViewModel>());
            });
        }

        public static NavigateToAboutFromMenu CreateNavigateToAboutFromMenu(HandleErrorAsync handleErrorAsync,
            NavigateToViewFromMenu navigateToView, IViewFactory viewFactory, SetMenuVisibility setMenuVisibility, NavigationPage navigationPage)
        {
            return () => handleErrorAsync(async () =>
            {
                setMenuVisibility(false);
                if (navigationPage.CurrentPage.GetType() != typeof(AboutView))
                    await navigateToView(viewFactory.Create<AboutView, AboutViewModel>());
            });
        }

        public static NavigateToSessionDetails CreateNavigateToSessionDetails(HandleErrorAsync handleErrorAsync,
            NavigateToView navigateToView, IViewFactory viewFactory)
        {
            return sessionId => handleErrorAsync(() =>
            {
                var vvm = viewFactory.Create<SessionDetailsView, SessionDetailsViewModel, SessionId>(sessionId);
                return navigateToView(vvm);
            });
        }

        public static NavigateToSpeakerDetails CreateNavigateToSpeakerDetails(HandleErrorAsync handleErrorAsync,
            NavigateToView navigateToView, IViewFactory viewFactory)
        {
            return speakerId => handleErrorAsync(() =>
            {
                var vvm = viewFactory.Create<SpeakerDetailsView, SpeakerDetailsViewModel, SpeakerId>(speakerId);
                return navigateToView(vvm);
            });
        }
    }
}
