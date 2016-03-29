using Xamarin.Forms;

namespace NCrafts.App.Sessions
{
    public partial class PersonalScheduleView : ContentPage
    {
        public PersonalScheduleView()
        {
            InitializeComponent();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
