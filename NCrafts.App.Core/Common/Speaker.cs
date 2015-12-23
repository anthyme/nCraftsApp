using System.Collections.Generic;

namespace NCrafts.App.Core.Common
{
    public class Speaker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string ProfilPicture { get; set; }
        public List<string> Skills { get; set; }
        public string Details { get; set; }
        public List<Session> Sessions { get; set; }
    }
}