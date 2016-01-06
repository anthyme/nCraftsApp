using System.Collections.Generic;
using NCrafts.App.Business.Common;
using NCrafts.App.Business.Core;

namespace NCrafts.App.Business.Sessions.Query
{
    public class SessionDetails
    {
        public SessionId Id { get; set; }
        public string Title { get; set; }
        public TimeSlot Interval { get; set; }
        //forbidden !! blocked by privacy ;-)
        //public Room Room { get; set; }
        //public List<Tag> Tags { get; set; }
        public string Tags { get; set; }
        public string Speakers { get; set; }
        public string Description { get; set; }
    }
}