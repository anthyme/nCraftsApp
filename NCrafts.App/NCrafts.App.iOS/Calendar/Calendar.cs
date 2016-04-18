using System.Diagnostics;
using NCrafts.App.Business.Common.Calendar;
using NCrafts.App.Business.Sessions.Query;
using NCrafts.App.iOS.Calendar;
using Xamarin.Forms;

// TODO: check to do this shit.
[assembly: Dependency(typeof(Calendar))]
namespace NCrafts.App.iOS.Calendar
{
    public class Calendar : ICalendar
    {
        public Calendar()
        {
        }

        public void SetSessionInCalendar(SessionCalendar session)
        {
        }

        public void DeleteSessionInCalendar(SessionCalendar session)
        {
        }
    }
}
