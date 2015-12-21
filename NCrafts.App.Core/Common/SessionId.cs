namespace NCrafts.App.Core.Common
{
    public struct SessionId
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
