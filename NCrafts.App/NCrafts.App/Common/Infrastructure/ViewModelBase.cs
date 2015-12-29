using System.Threading.Tasks;
using NCrafts.App.Core.Common.Infrastructure.Fx;
using ReactiveUI;

namespace NCrafts.App.Common.Infrastructure
{
    public class ViewModelBase : NotifyPropertyChanged
    {
        public Task Start()
        {
            return OnStart();
        }

        protected virtual Task OnStart()
        {
            return Task.FromResult(0); 
        }
    }
}
