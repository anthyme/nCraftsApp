using System;
using System.Linq.Expressions;

namespace NCrafts.App.Core.Common
{
    public class TimeSlot
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string GetHoursStartEnd()
        {
            return StartDate.ToString("HH:mm") + "-" + EndDate.ToString("HH:mm");
        }

        public string GetDateStart()
        {
            return StartDate.ToString("MM/dd/yy");
        }
    }
}