﻿using System;
using System.Collections.Generic;
using System.Linq;
using NCrafts.App.Core.Sessions.Query;
using NCrafts.App.Resx;
using Xamarin.Forms;

namespace NCrafts.App.Common.Converters
{
    public class SpeakerListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var speakers = (List<SpeakerSummary>)value;
            if (speakers?.Any() != true) return AppResources.NoSpeaker;
            return string.Join("\n", speakers.Select(x => x.FirstName + " " + x.LastName).ToArray());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}