using NCrafts.App.Business.Common.Infrastructure.Fx;

namespace NCrafts.App.Business.Common
{
    public struct SpeakerId : IId
    {
        private readonly string title;

        public SpeakerId(string title)
        {
            this.title = title;
        }

        public override string ToString()
        {
            return title;
        }
    }
}