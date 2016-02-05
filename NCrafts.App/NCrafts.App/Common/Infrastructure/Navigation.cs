using System.Linq;
using System.Threading.Tasks;
using NCrafts.App.Business.Common.Infrastructure;
using NCrafts.App.Menu;
using NCrafts.App.Sessions;
using NCrafts.App.Speakers;
using NCrafts.App.About;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public delegate Task NavigateToView(Page page, ViewModelBase viewModelBase);
    public delegate Task MenuOpenView(Page page, ViewModelBase viewModelBase);

    public class Navigation
    {
        public static NavigateToView CreateNavigateToView(NavigationPage navigationPage)
        {
            return async (view, vm) =>
            {
                var startTask = vm.Start();
                await navigationPage.PushAsync(view);
                await startTask;
            };
        }

        public static MenuOpenView CreateMenuOpenView(NavigationPage navigationPage)
        {
            return async (view, vm) =>
            {
                var startTask = vm.Start();
                navigationPage.Navigation.InsertPageBefore(view, navigationPage.Navigation.NavigationStack.First());
                await navigationPage.PopToRootAsync();
                await startTask;
            };
        }

        public static MenuOpenSessions CreateMenuOpenSessions(HandleErrorAsync handleErrorAsync, MenuOpenView menuOpenView, IViewFactory viewFactory)
        {
            return () => handleErrorAsync(() =>
            {
                var vvm = viewFactory.Create<SessionsView, SessionsViewModel>();
                return menuOpenView(vvm.View, vvm.ViewModel);
            });
        }

        public static MenuOpenTabbedDaily CreateMenuOpenTabbedDaily(HandleErrorAsync handleErrorAsync, MenuOpenView menuOpenView, IViewFactory viewFactory)
        {
            return () => handleErrorAsync(() =>
            {
                var vvm = viewFactory.Create<TabbedDailyView, TabbedDailyViewModel>();
                return menuOpenView(vvm.View, vvm.ViewModel);
            });
        }

        public static MenuOpenAbout CreateMenuOpenAbout(HandleErrorAsync handleErrorAsync, MenuOpenView menuOpenView, IViewFactory viewFactory)
        {
            return () => handleErrorAsync(() =>
            {
                var vvm = viewFactory.Create<AboutView, AboutViewModel>();
                return menuOpenView(vvm.View, vvm.ViewModel);
            });
        }

        public static MenuOpenSpeakers CreateMenuOpenSpeakers(HandleErrorAsync handleErrorAsync, MenuOpenView menuOpenView, IViewFactory viewFactory)
        {
            return () => handleErrorAsync(() =>
            {
                var vvm = viewFactory.Create<SpeakersView, SpeakersViewModel>();
                return menuOpenView(vvm.View, vvm.ViewModel);
            });
        }

        public static NavigateToMenu CreateNavigateToMenu(HandleErrorAsync handleErrorAsync,
            NavigateToView navigateToView, IViewFactory viewFactory)
        {
            return () => handleErrorAsync(() =>
            {
                var vvm = viewFactory.Create<MenuView, MenuViewModel>();
                return navigateToView(vvm.View, vvm.ViewModel);
            });
        }

        public static NavigateToSessions CreateNavigateToSessions(HandleErrorAsync handleErrorAsync,
            NavigateToView navigateToView, IViewFactory viewFactory)
        {
            return () => handleErrorAsync(() =>
            {
                var vvm = viewFactory.Create<SessionsView, SessionsViewModel>();
                return navigateToView(vvm.View, vvm.ViewModel);
            });
        }

        public static NavigateToSessionDetails CreateNavigateToSessionDetails(HandleErrorAsync handleErrorAsync,
            NavigateToView navigateToView, IViewFactory viewFactory)
        {
            return sessionId => handleErrorAsync(() =>
            {
                var vvm = viewFactory.Create<SessionDetailsView, SessionDetailsViewModel>();
                vvm.ViewModel.Init(sessionId);
                return navigateToView(vvm.View, vvm.ViewModel);
            });
        }

        public static NavigateToSpeakers CreateNavigateToSpeakers(HandleErrorAsync handleErrorAsync,
            NavigateToView navigateToView, IViewFactory viewFactory)
        {
            return () => handleErrorAsync(() =>
            {
                var vvm = viewFactory.Create<SpeakersView, SpeakersViewModel>();
                return navigateToView(vvm.View, vvm.ViewModel);
            });
        }

        public static NavigateToSpeakerDetails CreateNavigateToSpeakerDetails(HandleErrorAsync handleErrorAsync,
            NavigateToView navigateToView, IViewFactory viewFactory)
        {
            return speakerId => handleErrorAsync(() =>
            {
                var vvm = viewFactory.Create<SpeakerDetailsView, SpeakerDetailsViewModel>();
                vvm.ViewModel.Init(speakerId);
                return navigateToView(vvm.View, vvm.ViewModel);
            });
        }
    }
}
