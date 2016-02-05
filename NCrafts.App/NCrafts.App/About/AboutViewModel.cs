using System.Threading.Tasks;
using NCrafts.App.Common.Infrastructure;

namespace NCrafts.App.About
{
    public class AboutViewModel : ViewModelBase
    {
        protected override Task OnStart()
        {
            return Task.FromResult(0);
        }
    }
}