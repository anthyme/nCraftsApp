using System;
using System.Collections.Generic;
using System.Linq;
using NCrafts.App.Core.Common;
using NCrafts.App.Resx;
using Xamarin.Forms;

namespace NCrafts.App.Common.Converter
{
    public class SpeakerListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var speakers = (List<Speaker>)value;
            if (!(speakers?.Count > 0)) return AppResources.NoTagsText;
            var result = speakers.Aggregate("", (current, speaker) => current + speaker.FirstName + " " + speaker.LastName + "\n");
            result = result.Remove(result.Length - 1);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}