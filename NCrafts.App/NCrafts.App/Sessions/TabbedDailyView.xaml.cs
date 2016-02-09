using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using NCrafts.App.Business.Sessions.Command;
using NCrafts.App.Business.Sessions.Query;
using NCrafts.App.Common.Infrastructure;
using Xamarin.Forms;

namespace NCrafts.App.Sessions
{
    public partial class TabbedDailyView : TabbedPage
    {
        public TabbedDailyView(IViewFactory viewFactory, GetDaysNumberQuery getDaysNumberQuery)
        {
            List<int> days = getDaysNumberQuery();
            var cpmt = 1;

            foreach (var day in days)
            {
                var vvm = viewFactory.Create<DailySessionsView, DailySessionViewModel>();
                vvm.ViewModel.Day = day;
                vvm.ViewModel.Title = "D" + cpmt;
                Children.Add(vvm.View);
                var startTask = vvm.ViewModel.Start();
                ++cpmt;
            }
            InitializeComponent();
        }
    }
}
