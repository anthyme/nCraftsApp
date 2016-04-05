using NCrafts.App.Business.Sessions.Query;

namespace NCrafts.App.Business.Common.Calendar
{
    public interface ICalendar
    {
        void SetSessionInCalendar(SessionCalendar session);
        void DeleteSessionInCalendar(SessionCalendar session);
    }
}