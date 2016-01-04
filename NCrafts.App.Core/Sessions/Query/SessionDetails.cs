using System;
using System.Collections.Generic;
using NCrafts.App.Core.Common;

namespace NCrafts.App.Core.Sessions.Query
{
    public class SessionDetails
    {
        public SessionId Id { get; set; }
        public string Title { get; set; }
        public List<Speaker> Speakers { get; set; }
        public Interval Interval { get; set; }
        //public DateTime DateStart { get; set; }
        //public DateTime DateEnd { get; set; }
        public string Room { get; set; }
        public List<Tag> Tags { get; set; }
        public string Description { get; set; }
    }
}