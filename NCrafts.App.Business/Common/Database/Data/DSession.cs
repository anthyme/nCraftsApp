using System;
using SQLite.Net.Attributes;

namespace NCrafts.App.Business.Common.Database.Data
{
    public class DSession
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
    }
}
