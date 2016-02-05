using System.Collections.Generic;
using NCrafts.App.Business.Core.Data;

namespace NCrafts.App.Business.Menu.Query
{
    public delegate ICollection<MenuItem> GetMenuItemsQuery();

    class Queries
    {
        public static GetMenuItemsQuery CreateGetMenuItemsQuery(IDataSourceRepository dataSourceRepository)
        {
            return () => new List<MenuItem>
            {
                new MenuItem {Title = "Daily", ItemId = "0"},
                new MenuItem {Title = "Sessions", ItemId = "1"},
                new MenuItem {Title = "Speakers", ItemId = "2"},
                new MenuItem {Title = "About", ItemId = "3"},
            };
        }
    }
}