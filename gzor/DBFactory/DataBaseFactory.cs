using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gzor.DBFactory
{
    public class DataBaseFactory
    {
        public static object CreateFactory()
        {
            var dbType = Globalgzor.DataBaseConfig.DbType;
            object factory;
            if (dbType == DataBaseEnum.SQLServer)
            {
                factory = new SqlSeverHelper();
                return factory;
            }
            return null;
        }
    }
}
