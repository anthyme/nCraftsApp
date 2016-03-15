using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace NCrafts.App.Location
{
    public partial class LocationView : ContentPage
    {
        public LocationView()
        {
            var ncraftPosition = new Position(48.854092, 2.288256);
            InitializeComponent();
            my_map.MoveToRegion(new MapSpan(ncraftPosition, 0.01, 0.01));
            my_map.Pins.Add(new Pin { Label = "NCrafts 2016", Position = ncraftPosition, Address = "13 Quai de Grenelle, 75015 Paris" });
        }
    }
}
