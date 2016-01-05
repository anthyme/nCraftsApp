using System.Collections.Generic;

namespace NCrafts.App.Core.Common
{
    public class Speaker
    {
        public SpeakerId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string ProfilPicture { get; set; }
        public List<Skill> Skills { get; set; }
        public string Details { get; set; }
        public List<Session> Sessions { get; set; }
    }
}