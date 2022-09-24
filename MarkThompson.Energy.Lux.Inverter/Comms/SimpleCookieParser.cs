using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkThompson.Energy.Lux.Inverter.Comms
{
    internal class SimpleCookieParser
    {
        public static Dictionary<string,string> Parse(string token)
        {

            // "JSESSIONID=C4015F58970E0868A6A140A995C55861-n1; Path=/WManage; HttpOnly"

            Dictionary<string,string> ret=  new Dictionary<string,string>();    

            string[] cookies = token.Split(" ");

            foreach (string cookie in cookies)
            {
                string[] kvp = cookie.Split("=");
                
                if (kvp.Length == 2)
                {
                    if (!ret.ContainsKey(kvp[0]))
                    {
                        ret.Add(kvp[0], kvp[1].Trim(';'));
                    }
                } 
                else if (kvp.Length == 1)
                {
                    ret.Add(kvp[0], "");
                }
            }

            return ret;
        }

    }
}
