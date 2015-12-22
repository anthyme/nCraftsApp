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
                .RegisterType<NavigationPage>(new ContainerControlledLifetimeManager())
                .RegisterType<IViewFactory, ViewFactory>()
                .RegisterClosures<Logger>()
                .RegisterClosures<ErrorHandler>()
                .RegisterClosures<Navigation>()
                .RegisterClosures<Commands>()
                .RegisterClosures<Queries>()
                ;
        }
    }
}