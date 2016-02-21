using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace NCrafts.App.Menu
{
    public partial class MenuView : ContentPage
    {
        public MenuView(IUnityContainer dependencyContainer)
        {
            InitializeComponent();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
