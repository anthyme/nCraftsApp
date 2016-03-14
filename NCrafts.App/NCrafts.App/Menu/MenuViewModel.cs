using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using NCrafts.App.Business.Common.Infrastructure;
using NCrafts.App.Business.Menu.Command;
using NCrafts.App.Business.Menu.Query;
using NCrafts.App.Common.Infrastructure;
using Xamarin.Forms;
using MenuItem = NCrafts.App.Business.Menu.Query.MenuItem;

namespace NCrafts.App.Menu
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly GetMenuItemsQuery getMenuItemsQuery;
        private ObservableCollection<MenuItem> categories;

        public MenuViewModel(GetMenuItemsQuery getMenuItemsQuery)
        {
            OpenMenuItemCommand = new Command<MenuItem>(x => x.OpenCommand());
            this.getMenuItemsQuery = getMenuItemsQuery;
        }

        public ICommand OpenMenuItemCommand { get; }

        public ObservableCollection<MenuItem> Categories
        {
            get { return categories; }
            set { categories = value; OnPropertyChanged(); }
        }

        protected override Task OnStart()
        {
            Categories = new ObservableCollection<MenuItem>(getMenuItemsQuery());
            return Task.FromResult(0);
        }
    }
}