using Xamarin.Forms;

namespace NCrafts.App.Speakers
{
    public partial class SpeakersView : ContentPage
    {
        public SpeakersView()
        {
            InitializeComponent();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
