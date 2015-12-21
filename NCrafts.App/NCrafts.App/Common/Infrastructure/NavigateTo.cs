using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using NCrafts.App.Core.Common;
using NCrafts.App.Core.Common.Infrastructure;
using NCrafts.App.Sessions;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public class NavigateTo : INavigateTo
    {
        private readonly NavigationPage navigation;
        private readonly IUnityContainer container;

        public NavigateTo(NavigationPage navigation, IUnityContainer container)
        {
            this.navigation = navigation;
            this.container = container;
        }

        public Task Sessions()
        {
            return CreateLoadAndNavigateTo<SessionsView, SessionsViewModel>();
        }

        public Task Session(SessionId sessionId)
        {
            var vm = Create<SessionDetailsViewModel>();
            vm.Init(sessionId);
            return LoadAndNavigateTo(Create<SessionDetailsView>(), vm);
        }

        private Task CreateLoadAndNavigateTo<TView, TViewModel>() where TView : ContentPage where TViewModel : ViewModelBase
        {
            return LoadAndNavigateTo(Create<TView>(), Create<TViewModel>());
        }

        private async Task LoadAndNavigateTo(ContentPage view, ViewModelBase viewModel)
        {
            view.BindingContext = viewModel;
            await viewModel.Start();
            await navigation.PushAsync(view);
        }

        private T Create<T>()
        {
            return container.Resolve<T>();
        }
    }
}
