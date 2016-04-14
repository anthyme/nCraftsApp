using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace NCrafts.App.Business.Common.Database.Data
{
    public class DBSpeaker
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string IdString { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilPicture { get; set; }
        public string ProfilPictureIcon { get; set; }
        public string Details { get; set; }
        // MISSING the field book and language, set in other table maybe or with a long string and a separator
        public string Company { get; set; }
        public string Slide { get; set; }
        public string Site { get; set; }
        public string Twitter { get; set; }
        public string Github { get; set; }

        [ManyToMany(typeof(DBSessionSpeaker))]
        public List<DBSession> DSessions { get; set; }
    }
}
