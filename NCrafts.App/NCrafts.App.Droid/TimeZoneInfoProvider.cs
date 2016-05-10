using System;
using System.Linq;
using NCrafts.App.Business.Common.Infrastructure;
using NCrafts.App.Common.Infrastructure;
using NCrafts.App.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(TimeZoneInfoProvider))]
namespace NCrafts.App.Droid
{
    public class TimeZoneInfoProvider : ITimeZoneInfoProvider
    {
        public TimeZoneInfo Get()
        {
            try
            {
                var timezones = TimeZoneInfo.GetSystemTimeZones();
                return
                    timezones.FirstOrDefault(x => x.BaseUtcOffset.Hours == 1 && x.DisplayName.ToLower().Contains("paris")) ??
                    timezones.FirstOrDefault(x => x.BaseUtcOffset.Hours == 1 && x.SupportsDaylightSavingTime) 
                    ;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}