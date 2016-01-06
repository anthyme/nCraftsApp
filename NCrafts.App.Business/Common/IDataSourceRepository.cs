namespace NCrafts.App.Business.Common
{
    public interface IDataSourceRepository
    {
        DataSource Retreive();
    }

    public class DataSourceRepository : IDataSourceRepository
    {
        public DataSource Retreive()
        {
            return new DataSource();
        }
    }
}
