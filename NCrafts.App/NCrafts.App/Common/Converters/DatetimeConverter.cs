using System;
using NCrafts.App.Core.Common;
using NCrafts.App.Resx;
using Xamarin.Forms;

namespace NCrafts.App.Common.Converters
{
    public enum DateTimeConvertion
    {
        TextHours,
        TextDate,
        OnlyHours,
        OnlyDate,
        None
    }

    public class DatetimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return AppResources.NoDate;

            var type = (DateTimeConvertion)parameter;
            switch (type)
            {
                case DateTimeConvertion.TextHours:
                    return AppResources.HourText + ((TimeSlot)value).StartDate.ToString(AppResources.FormatHourMinute) + "-" + ((TimeSlot)value).EndDate.ToString(AppResources.FormatHourMinute);
                case DateTimeConvertion.OnlyHours:
                    return ((TimeSlot)value).StartDate.ToString(AppResources.FormatHourMinute) + "-" + ((TimeSlot)value).EndDate.ToString(AppResources.FormatHourMinute);
                case DateTimeConvertion.TextDate:
                    return AppResources.DateText + ((TimeSlot)value).StartDate.ToString(AppResources.FormatDateMonthDayYear);
                case DateTimeConvertion.OnlyDate:
                    return ((TimeSlot)value).StartDate.ToString(AppResources.FormatDateMonthDayYear);
                case DateTimeConvertion.None:
                    return AppResources.NoDate;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}