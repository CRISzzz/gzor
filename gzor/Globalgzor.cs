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

        public static string RootPath = AppDomain.CurrentDomain.BaseDirectory;

        public static string DefaultConnectString = File.ReadAllText(RootPath + "CONNECTSTRING.JSON");

        public static string EntireSqlCommands = File.ReadAllText(RootPath + "SQLCOMMANDS.JSON");
    }
}
