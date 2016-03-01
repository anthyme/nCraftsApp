using Xamarin.Forms;

namespace NCrafts.App.Speakers
{
    public partial class SpeakerDetailsView : ContentPage
    {
        public SpeakerDetailsView()
        {
            InitializeComponent();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
