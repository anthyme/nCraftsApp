using Xamarin.Forms;

namespace NCrafts.App.Common
{
    public class Shell : MasterDetailPage
    {
        public void SetMenuVisibility(bool isVisible)
        {
            IsPresented = isVisible;
        }

        public void SetMenuGestureEnable(bool isEnable)
        {
            IsGestureEnabled = isEnable;
        }
    }
}
