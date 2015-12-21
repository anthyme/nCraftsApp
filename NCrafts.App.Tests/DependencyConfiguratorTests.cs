using NCrafts.App.Common.Infrastructure;
using Xunit;

namespace NCrafts.App.Tests
{
    public class DependencyConfiguratorTests
    {
        [Fact]
        public void Configure()
        {
            DependencyConfigurator.Configure();
        }
    }
}
