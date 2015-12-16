using NCrafts.App.Common;
using NCrafts.App.Common.Infrastructure;
using Xamarin.Forms;

namespace NCrafts.App
{
    public class App : Application
    {
        public App()
        {
            var dataSource = new DataSource();
            var navigationPage = new NavigationPage();
            var navigateTo = new NavigateTo(navigationPage, dataSource);
            MainPage = navigationPage;
            navigateTo.Sessions();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
