using System.Collections.Generic;
using NCrafts.App.Business.Common;

namespace NCrafts.App.Business.Core
{
    class Speaker
    {
        public SpeakerId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilPicture { get; set; }
        public string ProfilPictureIcon { get; set; }
        public string Details { get; set; }
        public List<SessionId> Sessions { get; set; }
    }
}