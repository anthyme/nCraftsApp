using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NCrafts.App.Business.Menu.Command;
using NCrafts.App.Business.Speakers.Command;
using NCrafts.App.Common.Infrastructure;
using Xamarin.Forms;

namespace NCrafts.App.About
{
    public class AboutViewModel : ViewModelBase
    {
        public AboutViewModel(ReturnHomeCommand returnHomeCommand, OpenUrlCommand openUrlCommand, SetMenuGestureEnable setMenuGestureEnable)
        {
            setMenuGestureEnable(false);
            ReturnHomeCommand = new Command(() => returnHomeCommand());
            OpenMailCommand = new Command(() => openUrlCommand("mailto:anthyme.caillard@viseo.com"));
        }

        public ICommand ReturnHomeCommand { get; }

        public ICommand OpenMailCommand { get; }

        protected override Task OnStart()
        {
            return Task.FromResult(0);
        }
    }
}