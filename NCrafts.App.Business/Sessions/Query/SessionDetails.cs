using System.Collections.Generic;
using NCrafts.App.Business.Common;

namespace NCrafts.App.Business.Sessions.Query
{
    public class SessionDetails
    {
        public SessionId Id { get; set; }
        public string Title { get; set; }
        public TimeSlot Interval { get; set; }
        public Room Room { get; set; }
        public List<Tag> Tags { get; set; }
        public string Description { get; set; }
    }
}