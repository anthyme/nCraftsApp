using NCrafts.App.Droid.Database;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLitePlatform))]
namespace NCrafts.App.Droid.Database
{
    public class SQLitePlatform : SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid
    {
    }
}