using System;
using NCrafts.App.Core.Common;
using NCrafts.App.Resx;
using Xamarin.Forms;

namespace NCrafts.App.Common.Converter
{
    public class DatetimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value == null)
                return string.Empty;

            var type = (string)parameter;
            var datetime = (Interval)value;
            if (type.Equals(AppResources.TextAndHoursFormat, StringComparison.Ordinal))
                return AppResources.HourText + datetime.GetHoursStartEnd();
            if (type.Equals(AppResources.HoursFormatOnly, StringComparison.Ordinal))
                return datetime.GetHoursStartEnd();
            if (type.Equals(AppResources.TextAndDateFormat, StringComparison.Ordinal))
                return AppResources.DateText + datetime.GetDateStart(); ;
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}