using System.Threading.Tasks;
using NCrafts.App.Common.Infrastructure;

namespace NCrafts.App.Sessions
{
    public class TabbedDailyViewModel : ViewModelBase
    {
        protected override Task OnStart()
        {
            return Task.FromResult(0);
        }
    }
}