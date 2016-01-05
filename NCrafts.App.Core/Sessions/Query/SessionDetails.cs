using System;
using System.Collections.Generic;
using NCrafts.App.Core.Common;

namespace NCrafts.App.Core.Sessions.Query
{
    public class SessionDetails
    {
        public SessionId Id { get; set; }
        public string Title { get; set; }
        public List<SpeakerSummary> Speakers { get; set; }
        public TimeSlot Interval { get; set; }
        public Room Room { get; set; }
        public List<Tag> Tags { get; set; }
        public string Description { get; set; }
    }
}