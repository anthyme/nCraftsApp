using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
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
        private bool isMenuPresented;

        public MenuViewModel(
            OpenMenuItemCommand openMenuItemCommand,
            GetMenuItemsQuery getMenuItemsQuery)
        {
            OpenMenuItemCommand = new Command<string>(x => openMenuItemCommand(x));
            this.getMenuItemsQuery = getMenuItemsQuery;
        }

        public ICommand OpenMenuItemCommand { get; }

        public ObservableCollection<MenuItem> Categories
        {
            get { return categories; }
            set { categories = value; OnPropertyChanged(); }
        }

        public bool IsMenuPresented
        {
            get { return isMenuPresented; }
            set { isMenuPresented = value; OnPropertyChanged(); }
        }

        protected override Task OnStart()
        {
            Categories = new ObservableCollection<MenuItem>(getMenuItemsQuery());
            IsMenuPresented = false;
            return Task.FromResult(0);
        }
    }
}