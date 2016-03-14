namespace NCrafts.App.Business.Core.Data
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
