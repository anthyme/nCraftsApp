using Microsoft.Practices.Unity;
using NCrafts.App.Menu;
using NCrafts.App.Sessions;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public class App : Application
    {
        private IUnityContainer dependencyContainer;

        protected override void OnStart()
        {
            dependencyContainer = AppDependencyConfigurator.Configure();
            dependencyContainer.Resolve<NavigationPage>();
            var menuViewModel = dependencyContainer.Resolve<IViewFactory>().Create<MenuView, MenuViewModel>();
            menuViewModel.ViewModel.Start();
            MainPage = menuViewModel.View;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
