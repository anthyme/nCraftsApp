using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace NCrafts.App.Business.Common.Database.Data
{
    public class DBSession
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string IdString { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Room { get; set; }
        public bool IsRegister { get; set; }

        [ManyToMany(typeof(DBSessionSpeaker))]
        public List<DBSpeaker> DSpeakers { get; set; }

        [ManyToMany(typeof(DBSessionTag))]
        public List<DBTag> Tags { get; set; }
    }
}
