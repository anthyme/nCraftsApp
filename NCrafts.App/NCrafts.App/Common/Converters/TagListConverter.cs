using System;
using System.Collections.Generic;
using System.Linq;
using NCrafts.App.Core.Common;
using NCrafts.App.Resx;
using Xamarin.Forms;

namespace NCrafts.App.Common.Converters
{
    public class TagListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var tags = (List<Tag>) value;
            if (tags?.Any() != true) return AppResources.NoTag;
            return AppResources.TagsText + string.Join(AppResources.TagSeparator, tags.Select(x => x.Title).ToArray()) + ".";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}