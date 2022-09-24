using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarkThompson.Energy.Octopus.Energy.Comms
{
    internal class OctopusEnergyWebClient
    {

        public static WebProxy Proxy { get; set; }



        internal static string DoWebRequest(string apiKey, string url, string method = "GET", string payload = null)
        {
            Uri target = new Uri(url);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(target);
            request.Proxy = Proxy;

            request.Method = method;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            request.UserAgent = "Test Code - github.com/mthompson2/EnergyDemo";
            request.CookieContainer = new CookieContainer();
            request.Headers["Authorization"] = "Basic " + Base64Encode(apiKey);


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

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
