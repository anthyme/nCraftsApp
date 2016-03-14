using System;
using System.Threading.Tasks;

namespace NCrafts.App.Business.Menu.Query
{
    public class MenuItem
    {
        public Func<Task> OpenCommand { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
