using System.Collections.Generic;

namespace NCrafts.App.Business.Common
{
    public class Session
    {
        public SessionId Id { get; set; }
        public string Title { get; set; }
        public List<Speaker> Speakers { get; set; }
        public TimeSlot Interval { get; set; }
        public Room Room { get; set; }
        public List<Tag> Tags { get; set; }
        public string Description { get; set; }
    }
}
