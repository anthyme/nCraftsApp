using System.Diagnostics;
using System.Linq;
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
            // TODO: change the page where I arrive !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (tmp.WasInstalled)
            {
                tmp.GetAllFromDatabase(dependencyContainer.Resolve<IDataSourceRepository>());
            }
            else
            {
                tmp.StorageAllToDatabase(dependencyContainer.Resolve<IDataSourceRepository>());
            }
            // TODO: change those call super ugly...
            Task.Run(async () =>
            {
                var network = dependencyContainer.Resolve<NetworkClient>();
                await network.GetSessions(dependencyContainer.Resolve<IDataSourceRepository>());
                await network.GetSpeakers(dependencyContainer.Resolve<IDataSourceRepository>());
                if (network.IsSessionResponse || network.IsSpeakerResponse)
                {
                    tmp.StorageAllToDatabase(dependencyContainer.Resolve<IDataSourceRepository>());
                }
            });
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
