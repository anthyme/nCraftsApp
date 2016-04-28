using System.Collections.Generic;

namespace NCrafts.App.Business.Common.JsonSerializer.Data
{
    public class SessionModel
    {
        public IList<string> SpeakersId { get; set; }
        public string Details { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Place { get; set; }
        public string Title { get; set; }
        public string StartTime { get; set; }
        public int DurationInMinutes { get; set; }
        public IList<string> Tags { get; set; }
    }
}
