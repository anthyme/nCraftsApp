using System.Threading.Tasks;
using NCrafts.App.Core.Common.Infrastructure;
using NCrafts.App.Sessions;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public delegate Task NavigateToView(Page page, ViewModelBase viewModelBase);

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
    }
}
