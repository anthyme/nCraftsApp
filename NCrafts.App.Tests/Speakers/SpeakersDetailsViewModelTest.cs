using Microsoft.Practices.Unity;
using NCrafts.App.Business.Common;
using NCrafts.App.Speakers;
using Shouldly;
using Xunit;

namespace NCrafts.App.Tests.Speakers
{

    public class Given_a_SpeakerDetailsViewModel : IntegratedTest
    {
        [Fact]
        public async void When_starting_Then_Speakers_are_loaded()
        {
            var sut = Container.Resolve<SpeakerDetailsViewModel>(new ParameterOverride("id", new SpeakerId("1")));
            await sut.Start();

            sut.Speaker.ShouldNotBeNull();
            sut.Speaker.Id.ShouldBe(new SpeakerId("1"));
        }
    }
}