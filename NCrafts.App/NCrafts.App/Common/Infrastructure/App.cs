using Microsoft.Practices.Unity;
using NCrafts.App.Core.Common.Infrastructure;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public class App : Application
    {
        protected override void OnStart()
        {
            var dependencyContainer = DependencyConfigurator.Configure();
            var navigationPage = dependencyContainer.Resolve<NavigationPage>();
            var navigateTo = dependencyContainer.Resolve<INavigateTo>();
            MainPage = navigationPage;
            navigateTo.Sessions();
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
