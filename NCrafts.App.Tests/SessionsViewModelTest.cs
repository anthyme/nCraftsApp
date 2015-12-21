using System.Collections.Generic;
using NCrafts.App.Core.Common;
using NCrafts.App.Core.Sessions.Query;
using NCrafts.App.Sessions;
using Shouldly;
using Xunit;

namespace NCrafts.App.Tests
{
    public class Given_a_SessionsViewModel
    {
        [Fact]
        public async void When_starting_Then_sessions_are_loaded()
        {
            var summaries = new List<SessionSummary> {new SessionSummary {Id = new SessionId("1"), Title = "Hey"}};
            var sut = new SessionsViewModel(null, () => summaries);

            await sut.Start();

            sut.Sessions.ShouldNotBeEmpty();
            sut.Sessions.ShouldBe(summaries);
        }
    }
}
