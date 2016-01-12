using Microsoft.Practices.Unity;
using NCrafts.App.Speakers;
using Shouldly;
using Xunit;

namespace NCrafts.App.Tests.Speakers
{
    public class Given_a_SpeakersViewModel : IntegratedTest
    {
        [Fact]
        public async void When_starting_Then_speakers_are_loaded()
        {
            var sut = Container.Resolve<SpeakersViewModel>();

            await sut.Start();

            sut.Speakers.ShouldNotBeEmpty();
        }
    }
}