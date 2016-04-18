using System.IO;
using NCrafts.App.Business.Common.Database;
using NCrafts.App.iOS.Database;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHandler))]
namespace NCrafts.App.iOS.Database
{
    public class FileHandler : IFileHandler
    {
        public string GetFolderPath()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        }

        public bool IsFileExist(string path)
        {
            return File.Exists(path);
        }
    }
}
