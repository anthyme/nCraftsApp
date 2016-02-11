using System;
using System.Linq;
using System.Threading.Tasks;
using NCrafts.App.Business.Common.Infrastructure;
using NCrafts.App.Sessions;
using NCrafts.App.Speakers;
using NCrafts.App.About;
using NCrafts.App.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NCrafts.App.Common.Infrastructure
{
    public delegate Task NavigateToView(Page page, ViewModelBase viewModelBase);
    public delegate Task NavigateToViewFromMenu(Page page, ViewModelBase viewModelBase);
    public delegate Task MenuOpenView(Page page, ViewModelBase viewModelBase);

    public class Navigation
    {
        public static NavigateToView CreateNavigateToView(NavigationPage navigationPage)
        {
            return async (view, vm) =>
            {
                var startTask = vm.Start();
                await startTask;
                await navigationPage.PushAsync(view, false);
            };
        }

        public static NavigateToViewFromMenu CreateNavigateToViewFromMenu(NavigationPage navigationPage, MenuView menuView)
        {
            return async (view, vm) =>
            {
                var startTask = vm.Start();
                if (navigationPage.Navigation.NavigationStack.Count != 1)
                {
                    var tmp = navigationPage.Navigation.NavigationStack.First();
                    navigationPage.Navigation.InsertPageBefore(view, navigationPage.Navigation.NavigationStack.First());
                    await navigationPage.PopToRootAsync(false);
                    navigationPage.Navigation.InsertPageBefore(tmp, navigationPage.Navigation.NavigationStack.First());
                }
                else
                    await navigationPage.PushAsync(view, false);
                menuView.IsPresented = false;
                await startTask;
            };
        }

        public static MenuOpenView CreateMenuOpenView(NavigationPage navigationPage, MenuView menuView)
        {
            return async (view, vm) =>
            {
                var startTask = vm.Start();
                navigationPage.Navigation.InsertPageBefore(view, navigationPage.Navigation.NavigationStack.First());
                menuView.IsPresented = false;
                await startTask;
                await navigationPage.PopToRootAsync(false);
            };
        }

        public static MenuOpenTabbedDaily CreateMenuOpenTabbedDaily(HandleErrorAsync handleErrorAsync, MenuOpenView menuOpenView, IViewFactory viewFactory)
        {
            return () => handleErrorAsync(() =>
            {
                var vvm = viewFactory.Create<TabbedDailyView, TabbedDailyViewModel>();
                return menuOpenView(vvm.View, vvm.ViewModel);
            });
        }

        public static NavigateToMenuFromMenu CreateNavigateToMenuFromMenu(HandleErrorAsync handleErrorAsync, NavigationPage navigationPage, MenuView menuView)
        {
            return () => handleErrorAsync(async () =>
            {
                menuView.IsPresented = false;
                await navigationPage.PopToRootAsync(false);
            });
        }

        public static NavigateToSessionsFromMenu CreateNavigateToSessionsFromMenu(HandleErrorAsync handleErrorAsync,
            NavigateToViewFromMenu navigateToView, IViewFactory viewFactory)
        {
            return () => handleErrorAsync(() =>
            {
                var vvm = viewFactory.Create<SessionsView, SessionsViewModel>();
                return navigateToView(vvm.View, vvm.ViewModel);
            });
        }

        public static NavigateToSpeakersFromMenu CreateNavigateToSpeakersFromMenu(HandleErrorAsync handleErrorAsync,
            NavigateToViewFromMenu navigateToView, IViewFactory viewFactory)
        {
            return () => handleErrorAsync(() =>
            {
                var vvm = viewFactory.Create<SpeakersView, SpeakersViewModel>();
                return navigateToView(vvm.View, vvm.ViewModel);
            });
        }

        public static NavigateToAboutFromMenu CreateNavigateToAboutFromMenu(HandleErrorAsync handleErrorAsync,
            NavigateToViewFromMenu navigateToView, IViewFactory viewFactory)
        {
            return () => handleErrorAsync(() =>
            {
                var vvm = viewFactory.Create<AboutView, AboutViewModel>();
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
