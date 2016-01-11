﻿using Microsoft.Practices.Unity;
using NCrafts.App.Business.Common.Infrastructure;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public class App : Application
    {
        private IUnityContainer dependencyContainer;

        protected override void OnStart()
        {
            dependencyContainer = AppDependencyConfigurator.Configure();
            MainPage = dependencyContainer.Resolve<NavigationPage>();
            dependencyContainer.Resolve<NavigateToSpeakers>()();
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
