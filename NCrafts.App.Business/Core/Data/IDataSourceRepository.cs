namespace NCrafts.App.Business.Core.Data
{
    public interface IDataSourceRepository
    {
        DataSource Retreive();
    }

    public class DataSourceRepository : IDataSourceRepository
    {
        private readonly DataSource _dataSource;

        public DataSourceRepository()
        {
            _dataSource = new DataSource();
        }

        public DataSource Retreive()
        {
            return _dataSource;
        }
    }
}
