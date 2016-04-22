using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NCrafts.App.Business.Menu.Command;
using NCrafts.App.Common.Infrastructure;
using Xamarin.Forms;

namespace NCrafts.App.About
{
    public class AboutViewModel : ViewModelBase
    {
        public AboutViewModel(ReturnHomeCommand returnHomeCommand, SetMenuGestureEnable setMenuGestureEnable)
        {
            setMenuGestureEnable(false);
            ReturnHomeCommand = new Command(() => returnHomeCommand());
        }

        public ICommand ReturnHomeCommand { get; }


        protected override Task OnStart()
        {
            return Task.FromResult(0);
        }
    }
}