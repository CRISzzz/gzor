using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gzor.Model
{
    public class SqlCommand
    {
        public string SqlTextName { get; set; }

        public SqlCommandEnum CmdType { get; set; }

        public string SqlTextContent { get; set; }
    }
}
