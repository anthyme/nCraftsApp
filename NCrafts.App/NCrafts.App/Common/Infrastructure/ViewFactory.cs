using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace NCrafts.App.Common.Infrastructure
{
    public interface IViewFactory
    {
        ViewViewModel<TView, TViewModel> Create<TView, TViewModel>() where TView : Page;
    }

    public class ViewFactory : IViewFactory
    {
        private readonly IUnityContainer container;

        public ViewFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public ViewViewModel<TView, TViewModel> Create<TView, TViewModel>() where TView : Page
        {
            var vvm = new ViewViewModel<TView, TViewModel>(container.Resolve<TView>(), container.Resolve<TViewModel>());
            vvm.View.BindingContext = vvm.ViewModel;
            return vvm;
        }
    }

    public class ViewViewModel<TView, TViewModel>
    {
        public TView View { get; }
        public TViewModel ViewModel { get; }

        public ViewViewModel(TView view, TViewModel viewModel)
        {
            View = view;
            ViewModel = viewModel;
        }
    }
}