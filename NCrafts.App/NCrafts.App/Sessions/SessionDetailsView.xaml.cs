using Xamarin.Forms;

namespace NCrafts.App.Sessions
{
    public partial class SessionDetailsView : ContentPage
    {
        public SessionDetailsView()
        {
            InitializeComponent();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
