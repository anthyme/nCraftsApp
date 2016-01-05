using System.Collections.Generic;
using Microsoft.Practices.Unity;
using NCrafts.App.Core.Common;
using NCrafts.App.Core.Sessions.Query;
using NCrafts.App.Sessions;
using Shouldly;
using Xunit;

namespace NCrafts.App.Tests.Sessions
{
    public class Given_a_SessionsViewModel : IntegratedTest
    {
        [Fact]
        public async void When_starting_Then_sessions_are_loaded()
        {
            var sut = Container.Resolve<SessionsViewModel>();

            await sut.Start();

            sut.Sessions.ShouldNotBeEmpty();
        }
    }
}
