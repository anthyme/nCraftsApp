using Microsoft.Practices.Unity;
using NCrafts.App.Core.Common;
using NCrafts.App.Sessions;
using Shouldly;
using Xunit;

namespace NCrafts.App.Tests.Sessions
{
    public class Given_a_SessionDetailsViewModel : IntegratedTest
    {
        [Fact]
        public async void When_starting_Then_sessions_are_loaded()
        {
            var sut = Container.Resolve<SessionDetailsViewModel>();
            sut.Init(new SessionId("1"));

            await sut.Start();

            sut.Session.ShouldNotBeNull();
            sut.Session.Id.ShouldBe(new SessionId("1"));
        }
    }
}