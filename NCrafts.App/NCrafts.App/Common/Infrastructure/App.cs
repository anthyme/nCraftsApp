using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using NCrafts.App.Business.Common.Database;
using NCrafts.App.Business.Common.Network;
using NCrafts.App.Business.Core.Data;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public class App : Application
    {
        private IUnityContainer dependencyContainer;

        protected override void OnStart()
        {
            dependencyContainer = AppDependencyConfigurator.Configure();

            var tmp = dependencyContainer.Resolve<SQLDatabase>();
            // TODO: change those call super ugly...
            Task.Run(() => dependencyContainer.Resolve<NetworkClient>().GetSessions(dependencyContainer.Resolve<IDataSourceRepository>()));
            Task.Run(() => dependencyContainer.Resolve<NetworkClient>().GetSpeakers(dependencyContainer.Resolve<IDataSourceRepository>()));
            MainPage = dependencyContainer.Resolve<Bootstrap>()();
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
