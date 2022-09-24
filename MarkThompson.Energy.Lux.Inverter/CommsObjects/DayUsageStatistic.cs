using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkThompson.Energy.Lux.Inverter.CommsObjects
{
    public class DayUsageStatistic
    {
        public int solarPv { get; set; }
        public int gridPower { get; set; }
        public int batteryDischarging { get; set; }
        public int month { get; set; }
        public int hour { get; set; }
        public int year { get; set; }
        public int consumption { get; set; }
        public string time { get; set; }
        public int day { get; set; }
        public int minute { get; set; }
        public int second { get; set; }
    }

    public class DayUsageStatisticCollection
    {
        public string xAxis { get; set; }
        public List<DayUsageStatistic> data { get; set; }
        public bool success { get; set; }
    }

}
