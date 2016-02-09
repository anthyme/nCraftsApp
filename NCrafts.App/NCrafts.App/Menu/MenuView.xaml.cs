using Microsoft.Practices.Unity;
using NCrafts.App.Common.Infrastructure;
using NCrafts.App.Sessions;
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
    }
}
