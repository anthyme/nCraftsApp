using System.Collections.Generic;
using System.Linq;
using NCrafts.App.Business.Common.Infrastructure.Fx;
using Xamarin.Forms;

namespace NCrafts.App.Sessions
{
    public partial class TabbedDailyView : TabbedPage
    {
        public TabbedDailyView(IEnumerable<Page> childrenPages)
        {
            childrenPages.ForEach(Children.Add);
            InitializeComponent();
        }

        // TODO: see if title is a good option (Normally not possible to have two times the same title).
        // TODO: pb with title if we change it we have to change it everywhere (check to put it in resources)
        public void SetTabbedCurrentPage(string title)
        {
            CurrentPage = Children.Single(x => x.Title == title);
        }
    }
}
