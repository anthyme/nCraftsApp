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
                    return AppResources.HourText + ((TimeSlot)value).GetHoursStartEnd();
                case DateTimeConvertion.OnlyHours:
                    return ((TimeSlot)value).GetHoursStartEnd();
                case DateTimeConvertion.TextDate:
                    return AppResources.DateText + ((TimeSlot)value).GetDateStart();
                case DateTimeConvertion.OnlyDate:
                    return ((TimeSlot)value).GetDateStart(); ;
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