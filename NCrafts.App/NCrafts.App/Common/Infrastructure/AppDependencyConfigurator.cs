using Microsoft.Practices.Unity;
using NCrafts.App.Business.Common.Infrastructure;
using NCrafts.App.Business.Common.Infrastructure.Fx;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public class AppDependencyConfigurator
    {
        public static IUnityContainer Configure()
        {
            return DependencyConfigurator.Configure(new UnityContainer())
                .RegisterType<IViewFactory, ViewFactory>(AsSingleton)
                .RegisterType<NavigationPage>(AsSingleton)
                .RegisterClosures<Navigation>(AsSingleton)
                .RegisterClosures<Bootstrapper>(AsSingleton)
                ;
        }

        private static LifetimeManager AsSingleton => new ContainerControlledLifetimeManager();
    }
}