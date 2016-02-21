using System;
using System.Linq;
using System.Threading.Tasks;
using NCrafts.App.Business.Common.Infrastructure;
using NCrafts.App.Sessions;
using NCrafts.App.Speakers;
using NCrafts.App.About;
using NCrafts.App.Business.Common.Infrastructure.Fx;
using NCrafts.App.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NCrafts.App.Common.Infrastructure
{
    public delegate Task NavigateToView(Page page, ViewModelBase viewModelBase);
    public delegate Task NavigateToViewFromMenu(Page page, ViewModelBase viewModelBase);
    public delegate void SetMenuVisibility(bool isVisible);

    public class Navigation
    {
        public static NavigateToView CreateNavigateToView(NavigationPage navigationPage)
        {
            return async (view, vm) =>
            {
                var startTask = vm.Start();
                await navigationPage.PushAsync(view, true);
                await startTask;
            };
        }

        public static NavigateToViewFromMenu CreateNavigateToViewFromMenu(NavigationPage navigationPage, SetMenuVisibility setMenuVisibility)
        {
            return async (view, vm) =>
            {
                var startTask = vm.Start();

                setMenuVisibility(false);
                await navigationPage.PushAsync(view, true);
                navigationPage.Navigation.NavigationStack
                    .Skip(1)
                    .Take(navigationPage.Navigation.NavigationStack.Count - 2)
                    .ToList()
                    .ForEach(navigationPage.Navigation.RemovePage);
                await startTask;
            };
        }

        public static NavigateToTabbedDaily CreateMenuOpenTabbedDaily(NavigationPage navigationPage,
            SetMenuVisibility setMenuVisibility, IViewFactory viewFactory, HandleErrorAsync handleErrorAsync)
        {
            return () => handleErrorAsync(async () =>
            {
                var vvm = viewFactory.Create<TabbedDailyView, TabbedDailyViewModel>();
                var startTask = vvm.ViewModel.Start();
                setMenuVisibility(false);
                await navigationPage.PushAsync(vvm.View, false);
                navigationPage.Navigation.RemovePage(navigationPage.Navigation.NavigationStack.First());
                await startTask;
            });
        }

        public static NavigateToMenuFromMenu CreateNavigateToMenuFromMenu(
            HandleErrorAsync handleErrorAsync, NavigationPage navigationPage, SetMenuVisibility setMenuVisibility)
        {
            return () => handleErrorAsync(async () =>
            {
                setMenuVisibility(false);
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
