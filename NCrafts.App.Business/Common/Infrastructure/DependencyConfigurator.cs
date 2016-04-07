using Microsoft.Practices.Unity;
using NCrafts.App.Business.Common.Database;
using NCrafts.App.Business.Common.Infrastructure.Fx;
using NCrafts.App.Business.Common.Network;
using NCrafts.App.Business.Core.Data;

namespace NCrafts.App.Business.Common.Infrastructure
{
    public class DependencyConfigurator
    {
        public static IUnityContainer Configure(IUnityContainer container)
        {
            return container
                .RegisterType<IDataSourceRepository, DataSourceRepository>(AsSingleton)
                .RegisterType<NetworkClient>(AsSingleton)
                .RegisterType<SQLDatabase>(AsSingleton)
                .RegisterClosures<Logger>(AsSingleton)
                .RegisterClosures<ErrorHandler>(AsSingleton)
                .RegisterClosures<Sessions.Command.Commands>(AsSingleton)
                .RegisterClosures<Sessions.Query.Queries>(AsSingleton)
                .RegisterClosures<Speakers.Command.Commands>(AsSingleton)
                .RegisterClosures<Speakers.Query.Queries>(AsSingleton)
                .RegisterClosures<Menu.Command.Commands>(AsSingleton)
                .RegisterClosures<Menu.Query.Queries>(AsSingleton)
                ;
        }

        private static LifetimeManager AsSingleton => new ContainerControlledLifetimeManager();
    }
}
