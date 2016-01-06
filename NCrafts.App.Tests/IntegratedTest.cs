using Microsoft.Practices.Unity;
using NCrafts.App.Common.Infrastructure;

namespace NCrafts.App.Tests
{
    public class IntegratedTest
    {
        private static readonly IUnityContainer ParentContainer = AppDependencyConfigurator.Configure();
        protected IUnityContainer Container;

        public IntegratedTest()
        {
            Container = ParentContainer.CreateChildContainer();
        }
    }
}
