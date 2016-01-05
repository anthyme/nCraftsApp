using System;
using NCrafts.App.Core.Common;
using NCrafts.App.Resx;
using Xamarin.Forms;

namespace NCrafts.App.Common.Converter
{
    public enum DateConverterType
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

            var type = (DateConverterType)parameter;
            switch (type)
            {
                case DateConverterType.TextHours:
                    return AppResources.HourText + ((Interval)value).GetHoursStartEnd();
                case DateConverterType.OnlyHours:
                    return ((Interval)value).GetHoursStartEnd();
                case DateConverterType.TextDate:
                    return AppResources.DateText + ((Interval)value).GetDateStart();
                case DateConverterType.OnlyDate:
                    return ((Interval)value).GetDateStart(); ;
                case DateConverterType.None:
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