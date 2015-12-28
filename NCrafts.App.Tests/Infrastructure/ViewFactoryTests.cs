using System.Linq;
using Microsoft.Practices.Unity;
using NCrafts.App.Common.Infrastructure;
using NCrafts.App.Sessions;
using Shouldly;
using Xunit;

namespace NCrafts.App.Tests.Infrastructure
{
    public class Given_a_ViewFactory
    {
        [Fact]
        public void All_ViewModels_Should_be_created()
        {
            var viewAssembly = typeof(SessionsView).Assembly;
            var vmAssembly = typeof(SessionsViewModel).Assembly;

            var viewViewModelTypes = vmAssembly.GetTypes()
                .Where(x => typeof (ViewModelBase).IsAssignableFrom(x) && x != typeof(ViewModelBase))
                .Select(vm =>
                    new
                    {
                        ViewModel = vm,
                        View = viewAssembly.GetTypes()
                            .FirstOrDefault(v => v.Name == vm.Name.Substring(0, vm.Name.Length - 5))
                    }).ToList();

            var container = DependencyConfigurator.Configure();
            var sut = container.Resolve<ViewFactory>();

            foreach (var viewViewModelType in viewViewModelTypes)
            { 
                viewViewModelType.View.ShouldNotBeNull();
                var createMethod = sut.GetType().GetMethod("Create");
                createMethod = createMethod.MakeGenericMethod(viewViewModelType.View, viewViewModelType.ViewModel);
                var viewViewModel = createMethod.Invoke(sut, new object[0]);
                dynamic dviewViewModel = viewViewModel;
                object view = dviewViewModel.View;
                object vm = dviewViewModel.ViewModel;
                view.ShouldNotBeNull();
                vm.ShouldNotBeNull();
            }
        }
    }
}