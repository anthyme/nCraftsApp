using Microsoft.Practices.Unity;
using NCrafts.App.Common.Infrastructure;
using NCrafts.App.Business.Common.Infrastructure.Fx;
using Shouldly;
using Xunit;

namespace NCrafts.App.Tests.Infrastructure
{
    public class DependencyConfiguratorTest
    {
        [Fact]
        public void Configure_Should_work()
        {
            DependencyConfigurator.Configure();
        }

        [Fact]
        public void When_registering_closures_Then_they_create_different_instances()
        {
            var container = new UnityContainer().RegisterClosures<Navigation>();

            var instance1 = container.Resolve<NavigateToView>();
            var instance2 = container.Resolve<NavigateToView>();

            instance1.ShouldNotBe(instance2);
        }

        [Fact]
        public void When_registering_closures_as_singleton_Then_they_create_different_instances()
        {
            var container = new UnityContainer().RegisterClosures<Navigation>(new ContainerControlledLifetimeManager());

            var instance1 = container.Resolve<NavigateToView>();
            var instance2 = container.Resolve<NavigateToView>();

            instance1.ShouldBe(instance2);
        }
    }
}
