using System.Linq;
using Microsoft.Practices.Unity;
using NCrafts.App.Business.Common.Infrastructure;
using NCrafts.App.Menu;
using NCrafts.App.Sessions;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public delegate Shell Bootstrap();

    public class Bootstrapper
    {
        public static Bootstrap CreateBootstrap(IUnityContainer container, IViewFactory viewFactory, HandleErrorAsync handleErrorAsync,
            NavigationPage navigationPage)
        {
            return () =>
            {
                var shell = new Shell();
                container.RegisterInstance<SetMenuVisibility>(shell.SetMenuVisibility);

                shell.Detail = navigationPage;
                shell.Master = StartView<MenuView, MenuViewModel>(viewFactory, handleErrorAsync);

                StartFirstView(viewFactory, handleErrorAsync, navigationPage);

                return shell;
            };
        }

        private static void StartFirstView(IViewFactory viewFactory, HandleErrorAsync handleErrorAsync,
            NavigationPage navigationPage)
        {
            var daily = StartView<TabbedDailyView, TabbedDailyViewModel>(viewFactory, handleErrorAsync);
            handleErrorAsync(() => navigationPage.PushAsync(daily, false));
            navigationPage.Navigation.RemovePage(navigationPage.Navigation.NavigationStack.First());
        }

        private static TView StartView<TView,TViewModel>(IViewFactory viewFactory, HandleErrorAsync handleErrorAsync) 
            where TView : Page
            where TViewModel : ViewModelBase
        {
            var menu = viewFactory.Create<TView, TViewModel>();
            handleErrorAsync(() => menu.ViewModel.Start());
            return menu.View;
        }
    }
}
