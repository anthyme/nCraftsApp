using System;
using System.Linq.Expressions;

namespace NCrafts.App.Core.Common
{
    public class Interval
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public string GetHoursStartEnd()
        {
            return DateStart.ToString("HH:mm") + "-" + DateEnd.ToString("HH:mm");
        }

        public string GetDateStart()
        {
            return DateStart.ToString("MM/dd/yy");
        }
    }
}