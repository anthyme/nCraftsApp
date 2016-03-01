using NCrafts.App.Business.Common.Infrastructure.Fx;

namespace NCrafts.App.Business.Common
{
    public struct SessionId : IId
    {
        private readonly string title;

        public SessionId(string title)
        {
            this.title = title;
        }

        public override string ToString()
        {
            return title;
        }
    }
}
