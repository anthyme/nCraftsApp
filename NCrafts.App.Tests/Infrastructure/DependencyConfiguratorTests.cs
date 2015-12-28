using NCrafts.App.Common.Infrastructure;
using Xunit;

namespace NCrafts.App.Tests.Infrastructure
{
    public class Given_a_DependencyConfigurator
    {
        [Fact]
        public void Configure_Should_work()
        {
            DependencyConfigurator.Configure();
        }
    }
}
