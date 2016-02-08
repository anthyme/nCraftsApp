﻿using NCrafts.App.Business.Common;

namespace NCrafts.App.Business.Speakers.Query
{
    public class SpeakerDetails
    {
        public SpeakerId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Details { get; set; }
    }
}