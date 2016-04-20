using Xamarin.Forms;

namespace NCrafts.App.About
{
    public partial class AboutView : CarouselPage
    {
        public AboutView()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
    }
}
