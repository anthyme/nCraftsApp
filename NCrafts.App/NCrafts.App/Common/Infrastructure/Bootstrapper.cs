using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using NCrafts.App.About;
using NCrafts.App.Business.Common.Database;
using NCrafts.App.Business.Common.Infrastructure;
using NCrafts.App.Business.Common.Network;
using NCrafts.App.Business.Core.Data;
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
            NavigationPage navigationPage, GetDaysNumberQuery getDaysNumberQuery, SQLDatabase database)
        {
            return () =>
            {
                StartDataSource(container, database);

                var shell = new Shell();
                container.RegisterInstance<SetMenuVisibility>(shell.SetMenuVisibility);

                StartFirstView(container, viewFactory, handleErrorAsync, getDaysNumberQuery, navigationPage, database);

                shell.Detail = navigationPage;
                shell.Master = StartView<MenuView, MenuViewModel>(viewFactory, handleErrorAsync);

                return shell;
            };
        }

        private static void StartDataSource(IUnityContainer container, SQLDatabase database)
        {
            var dataSourceRepository = container.Resolve<IDataSourceRepository>();
            database.StartDatabase(dataSourceRepository);
            Task.Run(async () =>
            {
                var network = container.Resolve<NetworkClient>();
                await network.GetSessions(dataSourceRepository);
                await network.GetSpeakers(dataSourceRepository);
                if (network.IsSessionResponse || network.IsSpeakerResponse)
                {
                    database.StorageAllToDatabase(dataSourceRepository);
                }
            });
        }

        private static void StartFirstView(IUnityContainer container, IViewFactory viewFactory, HandleErrorAsync handleErrorAsync,
            GetDaysNumberQuery getDaysNumberQuery, NavigationPage navigationPage, SQLDatabase database)
        {
            var daily = StartView<TabbedDailyView, TabbedDailyViewModel>(viewFactory, handleErrorAsync, new ParameterOverride("childrenPages", GetTabbedChildrenViews(viewFactory, handleErrorAsync, getDaysNumberQuery)));
            container.RegisterInstance<SetTabbedCurrentPage>(daily.SetTabbedCurrentPage);
            if (!database.WasInstalled)
            {
                daily.SetTabbedCurrentPage("About");
            }
            handleErrorAsync(() => navigationPage.PushAsync(daily, false));
            navigationPage.Navigation.RemovePage(navigationPage.Navigation.NavigationStack.First());
        }

        private static List<Page> GetTabbedChildrenViews(IViewFactory viewFactory, HandleErrorAsync handleErrorAsync, GetDaysNumberQuery getDaysNumberQuery)
        {
            var days = getDaysNumberQuery();
            var cpmt = 0;
            var views = days.Select(day =>
                        StartView<DailySessionsView, DailySessionViewModel>(viewFactory, handleErrorAsync,
                                                                            new ParameterOverride("day", day),
                                                                            new ParameterOverride("title", "D" + ++cpmt)))
                                                                            .Cast<Page>().ToList();
            views.Add(StartView<AboutView, AboutViewModel>(viewFactory, handleErrorAsync));
            return views;
        }

        private static TView StartView<TView, TViewModel>(IViewFactory viewFactory, HandleErrorAsync handleErrorAsync, params ResolverOverride[] parameters)
            where TView : Page
            where TViewModel : ViewModelBase
        {
            var tabbed = viewFactory.Create<TView, TViewModel>(parameters);
            handleErrorAsync(() => tabbed.ViewModel.Start());
            return tabbed.View;
        }
    }
}
