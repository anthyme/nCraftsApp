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
            var sut = new SessionsViewModel(new SessionRespository());

            await sut.StartAsync();

            sut.Sessions.ShouldNotBeEmpty();
        }
    }
}
