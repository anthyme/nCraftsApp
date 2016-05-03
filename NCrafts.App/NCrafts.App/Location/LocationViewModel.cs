using System.Collections.Generic;
using NCrafts.App.Common.Infrastructure;
using Xamarin.Forms.Maps;

namespace NCrafts.App.Location
{
    public class LocationViewModel : ViewModelBase
    {
        private Position position;
        private IList<Pin> pins;

        public LocationViewModel()
        {
            position = new Position(48.8540799, 2.2860683);
            pins = new List<Pin>();
        }

        public IList<Pin> Pins
        {
            get { return pins; }
            set { pins = value; }
        } 

        public Position Position
        {
            get { return position; }
            set { position = value; OnPropertyChanged();}
        }
    }
}
