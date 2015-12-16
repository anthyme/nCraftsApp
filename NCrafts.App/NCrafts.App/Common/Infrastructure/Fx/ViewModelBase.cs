using System.Threading.Tasks;

namespace NCrafts.App.Common.Infrastructure.Fx
{
    public class ViewModelBase : Observable
    {
        public virtual Task Start()
        {
            return Task.FromResult(0);
        }
    }
}
