using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace NCrafts.App.Menu
{
    public partial class MenuView : MasterDetailPage
    {
        public MenuView(IUnityContainer dependencyContainer)
        {
            InitializeComponent();
            Detail = dependencyContainer.Resolve<NavigationPage>();
            dependencyContainer.RegisterInstance(this);
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
