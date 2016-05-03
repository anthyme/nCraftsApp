using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace NCrafts.App.Location
{
    public partial class LocationView : ContentPage
    {
        public LocationView()
        {
            var ncraftPosition = new Position(48.854092, 2.288256);
            var pin = new Pin
            {
                Label = "NCrafts 2016",
                Position = ncraftPosition,
                Address = "13 Quai de Grenelle, 75015 Paris",
                Type = PinType.Place
            };
            InitializeComponent();
            my_map.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, new Distance(1000)));
            my_map.Pins.Add(pin);
        }
    }
}
