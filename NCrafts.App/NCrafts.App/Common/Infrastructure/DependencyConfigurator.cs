using Microsoft.Practices.Unity;
using NCrafts.App.Core.Common;
using NCrafts.App.Core.Common.Infrastructure;
using NCrafts.App.Core.Common.Infrastructure.Fx;
using NCrafts.App.Core.Sessions.Command;
using NCrafts.App.Core.Sessions.Query;
using ReactiveUI;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public class DependencyConfigurator
    {
        public static IUnityContainer Configure()
        {
            return new UnityContainer()
                .RegisterType<IViewFactory, ViewFactory>(AsSingleton)
                .RegisterType<IMessageBus, MessageBus>(AsSingleton)
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