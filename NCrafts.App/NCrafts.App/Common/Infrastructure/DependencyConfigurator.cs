using Microsoft.Practices.Unity;
using NCrafts.App.Core.Common.Infrastructure;
using NCrafts.App.Core.Common.Infrastructure.Fx;
using NCrafts.App.Core.Sessions.Command;
using NCrafts.App.Core.Sessions.Query;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public class DependencyConfigurator
    {
        public static IUnityContainer Configure()
        {
            return new UnityContainer()
                .RegisterType<IViewFactory, ViewFactory>()
                .RegisterType<NavigationPage>(new ContainerControlledLifetimeManager())
                .RegisterClosures<Logger>(new ContainerControlledLifetimeManager())
                .RegisterClosures<ErrorHandler>(new ContainerControlledLifetimeManager())
                .RegisterClosures<Navigation>(new ContainerControlledLifetimeManager())
                .RegisterClosures<Commands>(new ContainerControlledLifetimeManager())
                .RegisterClosures<Queries>(new ContainerControlledLifetimeManager())
                ;
        }
    }
}