using SQLiteNetExtensions.Attributes;

namespace NCrafts.App.Business.Common.Database.Data
{
    public class DBSessionSpeaker
    {
        [ForeignKey(typeof(DBSession))]
        public int DSessionId { get; set; }

        [ForeignKey(typeof(DBSpeaker))]
        public int DSpeakerId { get; set; }
    }
}
