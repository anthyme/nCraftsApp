using Microsoft.Practices.Unity;
using NCrafts.App.Business.Common.Infrastructure.Fx;
using NCrafts.App.Business.Core.Data;
using NCrafts.App.Business.Sessions.Command;
using NCrafts.App.Business.Sessions.Query;

namespace NCrafts.App.Business.Common.Infrastructure
{
    public class DependencyConfigurator
    {
        public static IUnityContainer Configure(IUnityContainer container)
        {
            return container
                .RegisterType<IDataSourceRepository, DataSourceRepository>(AsSingleton)
                .RegisterClosures<Logger>(AsSingleton)
                .RegisterClosures<ErrorHandler>(AsSingleton)
                .RegisterClosures<Commands>(AsSingleton)
                .RegisterClosures<Queries>(AsSingleton)
                ;
        }

        private static LifetimeManager AsSingleton => new ContainerControlledLifetimeManager();
    }
}
