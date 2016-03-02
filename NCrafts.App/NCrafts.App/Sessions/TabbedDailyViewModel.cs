using System.Threading.Tasks;
using NCrafts.App.Common.Infrastructure;

namespace NCrafts.App.Sessions
{
    public class TabbedDailyViewModel : ViewModelBase
    {
        public TabbedDailyViewModel()
        {
        }

        protected override Task OnStart()
        {
            return Task.FromResult(0);
        }
    }
}