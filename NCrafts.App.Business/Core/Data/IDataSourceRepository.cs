namespace NCrafts.App.Business.Core.Data
{
    interface IDataSourceRepository
    {
        DataSource Retreive();
    }

    class DataSourceRepository : IDataSourceRepository
    {
        public DataSource Retreive()
        {
            return new DataSource();
        }
    }
}
