using Xamarin.Forms;

namespace NCrafts.App.Common
{
    public class Shell : MasterDetailPage
    {
        public void SetMenuVisibility(bool isVisible)
        {
            IsPresented = isVisible;
        }
    }
}
