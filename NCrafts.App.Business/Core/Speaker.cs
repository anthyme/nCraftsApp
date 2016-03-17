using System.Collections.Generic;
using NCrafts.App.Business.Common;

namespace NCrafts.App.Business.Core
{
    public class Speaker
    {
        public SpeakerId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilPicture { get; set; }
        public string ProfilPictureIcon { get; set; }
        public string Details { get; set; }
        public List<SessionId> Sessions { get; set; }
        public List<string> Languages { get; set; }
        public List<Book> Books { get; set; }
        public string Company { get; set; }
        public string Slide { get; set; }
        public string Site { get; set; }
        public string Twitter { get; set; }
        public string Github { get; set; }
    }
}