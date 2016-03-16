using System.Collections.Generic;

namespace NCrafts.App.Business.Common.Network.Data
{
    public class SessionModel
    {
        public string SpeakerId { get; set; }
        public string SpeakerName { get; set; }
        public string Abstract { get; set; }
        public string EventId { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Place { get; set; }
        public string Title { get; set; }
        public string StartTime { get; set; }
        public int Duration { get; set; }
        public IList<string> Tags { get; set; }
    }
}
