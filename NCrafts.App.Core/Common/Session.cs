using System;
using System.Collections.Generic;

namespace NCrafts.App.Core.Common
{
    public class Session
    {
        public SessionId Id { get; set; }
        public string Title { get; set; }
        public List<Speaker> Speakers { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Room { get; set; }
        public List<Tag> Tags { get; set; }
        public string Description { get; set; }
    }
}
