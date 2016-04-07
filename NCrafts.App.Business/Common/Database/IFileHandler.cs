namespace NCrafts.App.Business.Common.Database
{
    public interface IFileHandler
    {
        string GetFolderPath();
        bool IsFileExist(string path);
    }
}