using System.Threading.Tasks;
using NCrafts.App.Business.Common.Infrastructure.Fx;

namespace NCrafts.App.Common.Infrastructure
{
    public class ViewModelBase : Observable
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
