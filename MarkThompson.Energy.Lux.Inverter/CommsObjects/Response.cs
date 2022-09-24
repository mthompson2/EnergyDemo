using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkThompson.Energy.Lux.Inverter.CommsObjects
{
    public class Response<T>
    {
        public int Total { get; set; }
        public List<T> Rows { get; set; }
    }
}
