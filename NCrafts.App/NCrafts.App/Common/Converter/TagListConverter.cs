using System;
using System.Collections.Generic;
using System.Linq;
using NCrafts.App.Core.Common;
using NCrafts.App.Resx;
using Xamarin.Forms;

namespace NCrafts.App.Common.Converter
{
    public class TagListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var tags = (List<Tag>) value;
            if (!(tags?.Count > 0)) return AppResources.NoTag;
            var result = tags.Aggregate(AppResources.TagsText, (current, tag) => current + (tag.Title + AppResources.TagSeparator));
            result = result.Remove(result.Length - AppResources.TagSeparator.Length) + ".";
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}