using Microsoft.Practices.Unity;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Common.Infrastructure;
using NCrafts.App.Business.Common.Infrastructure.Fx;
using NCrafts.App.Business.Sessions.Command;
using NCrafts.App.Business.Sessions.Query;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public class DependencyConfigurator
    {
        public static IUnityContainer Configure()
        {
            return new UnityContainer()
                .RegisterType<IViewFactory, ViewFactory>(AsSingleton)
                .RegisterType<IDataSourceRepository, DataSourceRepository>(AsSingleton)
                .RegisterType<NavigationPage>(AsSingleton)
                .RegisterClosures<Logger>(AsSingleton)
                .RegisterClosures<ErrorHandler>(AsSingleton)
                .RegisterClosures<Navigation>(AsSingleton)
                .RegisterClosures<Commands>(AsSingleton)
                .RegisterClosures<Queries>(AsSingleton)
                ;
        }

        private static LifetimeManager AsSingleton => new ContainerControlledLifetimeManager();
    }
}