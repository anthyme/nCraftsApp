using SQLite.Net.Attributes;

namespace NCrafts.App.Business.Common.Database.Data
{
    public class DTag
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
