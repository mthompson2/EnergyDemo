using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkThompson.Energy.Lux.Inverter
{
    public class OctoConfiguration
    {
        public string APIKey { get; set; }

    
        public static OctoConfiguration Load()
        {
            string str = System.IO.File.ReadAllText("octoconfig.txt");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<OctoConfiguration>(str);
        }

        public void Save()
        {
            string str = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            System.IO.File.WriteAllText("octoconfig.txt", str);
        }
    }
}
