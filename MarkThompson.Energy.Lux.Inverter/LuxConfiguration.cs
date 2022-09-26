using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkThompson.Energy.Lux.Inverter
{
    public class LuxConfiguration
    {
        public string Username { get; set; }

        public string Password { get; set; }


        public string InverterSerialNumber { get; set; }

        public static LuxConfiguration Load()
        {
            string str = System.IO.File.ReadAllText("luxconfig.txt");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<LuxConfiguration>(str);
        }

        public void Save()
        {
            string str = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            System.IO.File.WriteAllText("luxconfig.txt", str);
        }
    }
}
