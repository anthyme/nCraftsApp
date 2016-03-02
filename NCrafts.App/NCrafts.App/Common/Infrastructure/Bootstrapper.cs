using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using NCrafts.App.About;
using NCrafts.App.Business.Common.Infrastructure;
using NCrafts.App.Business.Sessions.Query;
using NCrafts.App.Menu;
using NCrafts.App.Sessions;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public delegate Shell Bootstrap();

    public class Bootstrapper
    {
        public static Bootstrap CreateBootstrap(IUnityContainer container, IViewFactory viewFactory, HandleErrorAsync handleErrorAsync,
            NavigationPage navigationPage, GetDaysNumberQuery getDaysNumberQuery)
        {
            return () =>
            {
                var shell = new Shell();
                container.RegisterInstance<SetMenuVisibility>(shell.SetMenuVisibility);

                StartFirstView(container, viewFactory, handleErrorAsync, getDaysNumberQuery, navigationPage);

                shell.Detail = navigationPage;
                shell.Master = StartView<MenuView, MenuViewModel>(viewFactory, handleErrorAsync);

                return shell;
            };
        }

        private static void StartFirstView(IUnityContainer container, IViewFactory viewFactory, HandleErrorAsync handleErrorAsync,
            GetDaysNumberQuery getDaysNumberQuery, NavigationPage navigationPage)
        {
            var daily = StartView<TabbedDailyView, TabbedDailyViewModel>(viewFactory, handleErrorAsync, GetTabbedChildrenViews(viewFactory, handleErrorAsync, getDaysNumberQuery));
            container.RegisterInstance<SetTabbedCurrentPage>(daily.SetTabbedCurrentPage);
            daily.SetTabbedCurrentPage("About");
            handleErrorAsync(() => navigationPage.PushAsync(daily, false));
            navigationPage.Navigation.RemovePage(navigationPage.Navigation.NavigationStack.First());
        }

        private static List<Page> GetTabbedChildrenViews(IViewFactory viewFactory, HandleErrorAsync handleErrorAsync, GetDaysNumberQuery getDaysNumberQuery)
        {
            var views = new List<Page>();
            // TODO: check to make a query that already 
            var days = getDaysNumberQuery();
            var cpmt = 0;
            
            foreach (var day in days)
            {
                var vvm = viewFactory.Create<DailySessionsView, DailySessionViewModel>(new ParameterOverride("day", day), new ParameterOverride("title", "D" + ++cpmt));
                views.Add(vvm.View);
                vvm.ViewModel.Start();
            }
            views.Add(StartView<AboutView, AboutViewModel>(viewFactory, handleErrorAsync));
            return views;
        }

        // TODO: factorise those 2 methods
        private static TView StartView<TView, TViewModel>(IViewFactory viewFactory, HandleErrorAsync handleErrorAsync)
            where TView : Page
            where TViewModel : ViewModelBase
        {
            var menu = viewFactory.Create<TView, TViewModel>();
            handleErrorAsync(() => menu.ViewModel.Start());
            return menu.View;
        }

        private static TView StartView<TView, TViewModel>(IViewFactory viewFactory, HandleErrorAsync handleErrorAsync, List<Page> dailySessionsViews)
            where TView : Page
            where TViewModel : ViewModelBase
        {
            var tabbed = viewFactory.Create<TView, TViewModel>(new ParameterOverride("childrenPages", dailySessionsViews));
            handleErrorAsync(() => tabbed.ViewModel.Start());
            return tabbed.View;
        }
    }
}
