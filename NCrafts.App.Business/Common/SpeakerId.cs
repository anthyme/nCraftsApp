namespace NCrafts.App.Business.Common
{
    public class SpeakerId
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