using System.Collections.Generic;
using NCrafts.App.Business.Common;

namespace NCrafts.App.Business.Speakers.Query
{
    public class SpeakerDetails
    {
        public SpeakerId Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string ProfilPicture { get; set; }
        public string Twitter { get; set; }
        public string Company { get; set; }
        public string Github { get; set; }
        public List<SessionId> SessionsId { get; set; } 
    }
}