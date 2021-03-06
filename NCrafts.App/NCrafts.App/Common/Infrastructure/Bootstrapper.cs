﻿using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using NCrafts.App.About;
using NCrafts.App.Business.Common.Database;
using NCrafts.App.Business.Common.Infrastructure;
using NCrafts.App.Business.Common.JsonSerializer;
using NCrafts.App.Business.Common.Network;
using NCrafts.App.Business.Core.Data;
using NCrafts.App.Menu;
using NCrafts.App.Sessions;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public delegate Shell Bootstrap();

    public class Bootstrapper
    {
        public static Bootstrap CreateBootstrap(IUnityContainer container, IViewFactory viewFactory, HandleErrorAsync handleErrorAsync,
            NavigationPage navigationPage, SQLDatabase database)
        {
            return () =>
            {
                StartDataSource(container, database);

                var shell = new Shell();
                container.RegisterInstance<SetMenuVisibility>(shell.SetMenuVisibility);
                container.RegisterInstance<SetMenuGestureEnable>(shell.SetMenuGestureEnable);

                StartFirstView(viewFactory, handleErrorAsync, navigationPage);

                shell.Detail = navigationPage;
                shell.Master = StartView<MenuView, MenuViewModel>(viewFactory, handleErrorAsync);

                navigationPage.Popped += (sender, args) =>
                {
                    shell.SetMenuGestureEnable(true);
                };

                if (!database.WasInstalled)
                {
                    navigationPage.PushAsync(StartView<AboutView, AboutViewModel>(viewFactory, handleErrorAsync));
                    NavigationPage.SetHasNavigationBar(navigationPage, false);
                }
                return shell;
            };
        }

        private static void ExtractDataFromEmbedded(IDataSourceRepository dataSourceRepository)
        {
            var assembly = typeof(Bootstrapper).GetTypeInfo().Assembly;

            var streamSessions = assembly.GetManifestResourceStream("NCrafts.App.Resx.sessions.json");
            var streamReaderSessions = new StreamReader(streamSessions);
            var resultsSessions = Converter.GetSessionsAndTagsFromJson(streamReaderSessions.ReadToEnd());

            var streamSpeakers = assembly.GetManifestResourceStream("NCrafts.App.Resx.speakers.json");
            var streamReaderSpeakers = new StreamReader(streamSpeakers);
            var resultsSpeakers = Converter.GetSpeakersFromJson(streamReaderSpeakers.ReadToEnd());

            dataSourceRepository.Retreive().AddSessions(resultsSessions.Item1);
            dataSourceRepository.Retreive().AddTags(resultsSessions.Item2);
            dataSourceRepository.Retreive().AddSpeakers(resultsSpeakers);
        } 

        private static void StartDataSource(IUnityContainer container, SQLDatabase database)
        {
            var dataSourceRepository = container.Resolve<IDataSourceRepository>();
            if (!database.WasInstalled)
            {
                ExtractDataFromEmbedded(dataSourceRepository);
            }
            database.StartDatabase(dataSourceRepository);
            Task.Run(async () =>
            {
                var network = container.Resolve<NetworkClient>();
                await network.GetConf();
                await network.GetSessions(dataSourceRepository);
                await network.GetSpeakers(dataSourceRepository);
                if (network.IsSessionResponse || network.IsSpeakerResponse)
                {
                    database.StorageAllToDatabase(dataSourceRepository);
                }
            });
        }

        private static void StartFirstView(IViewFactory viewFactory, HandleErrorAsync handleErrorAsync, NavigationPage navigationPage)
        {
            var sessions = StartView<SessionsView, SessionsViewModel>(viewFactory, handleErrorAsync);
            handleErrorAsync(() => navigationPage.PushAsync(sessions, false));
            navigationPage.Navigation.RemovePage(navigationPage.Navigation.NavigationStack.First());
        }

        private static TView StartView<TView, TViewModel>(IViewFactory viewFactory, HandleErrorAsync handleErrorAsync, params ResolverOverride[] parameters)
            where TView : Page
            where TViewModel : ViewModelBase
        {
            var viewViewModel = viewFactory.Create<TView, TViewModel>(parameters);
            handleErrorAsync(() => viewViewModel.ViewModel.Start());
            return viewViewModel.View;
        }
    }
}
