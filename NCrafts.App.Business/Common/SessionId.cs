namespace NCrafts.App.Business.Common
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
