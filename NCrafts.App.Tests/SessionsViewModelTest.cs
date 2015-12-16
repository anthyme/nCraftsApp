using System.Windows.Input;
using NCrafts.App.Common;
using NCrafts.App.Sessions;
using NCrafts.App.Sessions.Commands;
using NCrafts.App.Sessions.Queries;
using Shouldly;
using Xunit;

namespace NCrafts.App.Tests
{
    public class Given_a_SessionsViewModel
    {
        [Fact]
        public async void When_starting_Then_sessions_are_loaded()
        {
            var selectSessionCommand = NSubstitute.Substitute.For<ICommand>();
            var sut = new SessionsViewModel(selectSessionCommand, new GetAllSessionsQuery(new DataSource()));

            await sut.Start();

            sut.Sessions.ShouldNotBeEmpty();
        }
    }
}
