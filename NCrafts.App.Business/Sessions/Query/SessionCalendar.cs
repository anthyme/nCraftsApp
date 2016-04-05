using NCrafts.App.Business.Common;

namespace NCrafts.App.Business.Sessions.Query
{
    public class SessionCalendar
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSlot Date { get; set; }
    }
}
