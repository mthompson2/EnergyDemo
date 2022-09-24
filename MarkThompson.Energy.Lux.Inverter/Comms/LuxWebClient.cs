using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarkThompson.Energy.Lux.Inverter.Comms
{
    public class OctopusEnergyWebClient
    {
        public static WebProxy Proxy { get; set; }

        public static string GetJavaSessionId()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://server.luxpowertek.com/WManage/web/monitor/inverter");
            request.Proxy = Proxy;
 
            request.Method = "POST";
            request.Accept = "application/json";

            request.UserAgent = "Test Code - github.com/mthompson2/EnergyDemo";


            // grab te response and print it out to the console along with the status code
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string cookie = response.Headers["set-cookie"];
            Dictionary<string, string> map = SimpleCookieParser.Parse(cookie);

            return map["JSESSIONID"];
        }


  
        internal static string DoWebRequest(string session, string url, string method="GET", string payload = null)
        {
            Uri target = new Uri(url);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(target);
            request.Proxy = Proxy;

            request.Method = method;
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.UserAgent = "Test Code - github.com/mthompson2/EnergyDemo";
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Cookie() { Name = "JSESSIONID", Value = System.Web.HttpUtility.UrlEncode(session), Domain = target.Host });

            if (payload != null)
            {
                request.ContentType = "application/x-www-form-urlencoded";
                // turn our request string into a byte stream
                byte[] postBytes = Encoding.UTF8.GetBytes(payload);


                Stream requestStream = request.GetRequestStream();
                request.ContentLength = postBytes.Length;
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string result;
            using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
            {
                result = rdr.ReadToEnd();
            }


            return result;
        }
    }
}
