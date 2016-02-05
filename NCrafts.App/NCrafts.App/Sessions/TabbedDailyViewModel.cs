using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NCrafts.App.Business.Sessions.Query;
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