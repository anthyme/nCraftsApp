using System;
using Xamarin.Forms;

namespace NCrafts.App.Sessions
{
    public class DatetimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var datetime = (DateTime)value;
            var type = int.Parse((string)parameter);
            switch (type)
            {
                case 0:
                    return "Date: " + datetime.ToString("MM/dd/yy");
                case 1:
                    return "Hours: " + datetime.ToString("HH:mm");
                case 2:
                    return " - " + datetime.ToString("HH:mm");
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}