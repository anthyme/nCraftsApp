using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCrafts.App.Sessions;
using Xamarin.Forms;

namespace NCrafts.App
{
    public class App : Application
    {
        public App()
        {
            var vm = new SessionsViewModel(new SessionRespository());
            MainPage = new SessionsView() { BindingContext = vm };
            vm.StartAsync();
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
