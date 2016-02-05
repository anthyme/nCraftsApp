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
            var vvmTabbed = dependencyContainer.Resolve<IViewFactory>().Create<TabbedDailyView, TabbedDailyViewModel>();
            Detail = dependencyContainer.Resolve<NavigationPage>(new ParameterOverride("root", vvmTabbed.View));
            vvmTabbed.ViewModel.Start();
        }
    }
}
