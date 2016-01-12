namespace NCrafts.App.Business.Common
{
    public struct SpeakerId
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