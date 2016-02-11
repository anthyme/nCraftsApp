using System.Collections.Generic;
using NCrafts.App.Business.Common;

namespace NCrafts.App.Business.Speakers.Query
{
    public class SpeakerDetails
    {
        public SpeakerId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Details { get; set; }
        public string ProfilPicture { get; set; }
        public List<SessionId> SessionsIds { get; set; } 
    }
}