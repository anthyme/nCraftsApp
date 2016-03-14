using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace NCrafts.App.Droid
{
    [Activity(Label = "NCrafts", Icon = "@drawable/icon", MainLauncher = true, NoHistory = true, Theme = "@style/MyTheme.Splash",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}