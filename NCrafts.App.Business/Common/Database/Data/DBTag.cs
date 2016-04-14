using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace NCrafts.App.Business.Common.Database.Data
{
    public class DBTag
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }

        [ManyToMany(typeof(DBSessionTag))]
        public List<DBSession> Sessions { get; set; }
    }
}
