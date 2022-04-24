using gzor.DBFactory;
using gzor.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gzor
{
    public static class Globalgzor
    {

        private static string RootPath = AppDomain.CurrentDomain.BaseDirectory;

        public static DataBaseConfig DataBaseConfig = JsonConvert.DeserializeObject<DataBaseConfig>(File.ReadAllText(RootPath + "DATABASECONFIG.JSON"));

        public static List<SqlCommand> EntireSqlCommands = JsonConvert.DeserializeObject<List<SqlCommand>>(File.ReadAllText(RootPath + "SQLCOMMANDS.JSON"));

        public static object DataBaseUtil = DataBaseFactory.CreateFactory(DataBaseConfig.DbType);
    }
}
