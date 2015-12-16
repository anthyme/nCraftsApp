using System.Threading.Tasks;
using NCrafts.App.Common.Infrastructure.Fx;
using NCrafts.App.Sessions;
using NCrafts.App.Sessions.Commands;
using NCrafts.App.Sessions.Queries;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public interface INavigateTo
    {
        Task Session(int sessionId);
        Task Sessions();
    }

    public class NavigateTo : INavigateTo
    {
        private readonly NavigationPage navigation;
        private readonly DataSource dataSource;

        public NavigateTo(NavigationPage navigation, DataSource dataSource)
        {
            this.navigation = navigation;
            this.dataSource = dataSource;
        }

        public Task Sessions()
        {
            var vm = new SessionsViewModel(new SelectSessionCommand(this), new GetAllSessionsQuery(dataSource));
            var view = new SessionsView();
            return LoadAndNavigateTo(view, vm);
        }

        public Task Session(int sessionId)
        {
            var vm = new SessionDetailsViewModel(new GetSessionByIdQuery(dataSource));
            vm.Init(sessionId);
            var view = new SessionDetailsView();
            return LoadAndNavigateTo(view, vm);
        }

        private async Task LoadAndNavigateTo(ContentPage view, ViewModelBase viewModel)
        {
            view.BindingContext = viewModel;
            await viewModel.Start();
            await navigation.PushAsync(view);
        }
    }
}
