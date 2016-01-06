using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCrafts.App.Core.Common
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
