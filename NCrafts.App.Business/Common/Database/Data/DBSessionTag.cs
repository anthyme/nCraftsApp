using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace NCrafts.App.Business.Common.Database.Data
{
    public class DBSessionTag
    {
        [ForeignKey(typeof(DBSession))]
        public int SessionId { get; set; }

        [ForeignKey(typeof(DBTag))]
        public int TagId { get; set; }
    }
}
