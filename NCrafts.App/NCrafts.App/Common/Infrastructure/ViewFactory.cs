using Microsoft.Practices.Unity;
using NCrafts.App.Business.Common.Infrastructure.Fx;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public interface IViewFactory
    {
        ViewViewModel<TView, TViewModel> Create<TView, TViewModel>() where TView : Page where TViewModel : ViewModelBase;
        ViewViewModel<TView, TViewModel> Create<TView, TViewModel, TId>(TId id) where TView : Page where TViewModel : ViewModelBase where TId : IId;
    }

    public class ViewFactory : IViewFactory
    {
        private readonly IUnityContainer container;

        public ViewFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public ViewViewModel<TView, TViewModel> Create<TView, TViewModel>() where TView : Page where TViewModel : ViewModelBase
        {
            var vvm = new ViewViewModel<TView, TViewModel>(container.Resolve<TView>(), container.Resolve<TViewModel>());
            vvm.View.BindingContext = vvm.ViewModel;
            return vvm;
        }

        public ViewViewModel<TView, TViewModel> Create<TView, TViewModel, TId>(TId id) where TView : Page where TViewModel : ViewModelBase where TId : IId
        {
            var vvm = new ViewViewModel<TView, TViewModel>(container.Resolve<TView>(), container.Resolve<TViewModel>(new ParameterOverride("id", id)));
            vvm.View.BindingContext = vvm.ViewModel;
            return vvm;
        }
    }

    public interface IViewViewModel
    {
        Page View { get; }
        ViewModelBase ViewModel { get; }
    }

    public class ViewViewModel<TView, TViewModel> : IViewViewModel
        where TView : Page
        where TViewModel : ViewModelBase
    {
        public TView View { get; }
        public TViewModel ViewModel { get; }

        public ViewViewModel(TView view, TViewModel viewModel)
        {
            View = view;
            ViewModel = viewModel;
        }

        Page IViewViewModel.View => View;
        ViewModelBase IViewViewModel.ViewModel => ViewModel;
    }
}