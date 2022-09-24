using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkThompson.Energy.Lux.Inverter.CommsObjects
{
    public class PlantInfo
    {
        public string Country { get; set; }
        public int CurrentTimezone { get; set; }
        public string Timezone { get; set; }
        public bool NoticeWarn { get; set; }
        public int PlantId { get; set; }
        public bool NoticeFault { get; set; }
        public int NominalPower { get; set; }
        public bool DaylightSavingTime { get; set; }
        public string Name { get; set; }
        public string NoticeEmail { get; set; }
        public int Id { get; set; }
        public string CreateDate { get; set; }
    }
}
