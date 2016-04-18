using NCrafts.App.iOS.Database;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLitePlatform))]
namespace NCrafts.App.iOS.Database
{
    public class SQLitePlatform : SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS
    {
    }
}
