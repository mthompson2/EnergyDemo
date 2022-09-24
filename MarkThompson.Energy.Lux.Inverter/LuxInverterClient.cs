using MarkThompson.Energy.Lux.Inverter.CommsObjects;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MarkThompson.Energy.Lux.Inverter
{
    public class LuxInverterClient
    {
        public string SessionId { get; set; }




        public void Authenticate(string username, string password)
        {
             SessionId = Comms.OctopusEnergyWebClient.GetJavaSessionId();
            string payload  = string.Format("account={0}&password={1}", username, password);

            string url = "https://server.luxpowertek.com/WManage/web/login";

            Comms.OctopusEnergyWebClient.DoWebRequest(SessionId, url, "POST", payload);

        }

        public List<CommsObjects.PlantInfo> ListPlants()
        {
            string url = "https://server.luxpowertek.com/WManage/web/config/plant/list/viewer";

            string results = Comms.OctopusEnergyWebClient.DoWebRequest(SessionId, url, "POST");

            Response<PlantInfo>  ret = JsonConvert.DeserializeObject<Response<PlantInfo>>(results);
            return ret.Rows;
        }

        public List<CommsObjects.InverterInfo> ListInverters(int plantId)
        {
            string url = "https://server.luxpowertek.com/WManage/web/config/inverter/list";


            string payload = string.Format($"page=1&rows=200&plantId={plantId}"); // Return a maximum of 200 inverters


            string results = Comms.OctopusEnergyWebClient.DoWebRequest(SessionId, url, "POST", payload);
            Response<InverterInfo> ret = JsonConvert.DeserializeObject<Response<InverterInfo>>(results);
            return ret.Rows;
        }
        


        public InverterRuntime GetInverterCurrentInfo(string inverterSerialNUmber)
        {
            string url = "https://server.luxpowertek.com/WManage/api/inverter/getInverterRuntime";
            string payload = string.Format("serialNum={0}", inverterSerialNUmber);


            string results = Comms.OctopusEnergyWebClient.DoWebRequest(SessionId, url, "POST", payload);
            InverterRuntime ret = JsonConvert.DeserializeObject<InverterRuntime>(results);
            return ret;
        }

        public List<DayUsageStatistic> GetStatsForDate(string inverterSerialNUmber, DateTime dt)
        {

            string url = "https://server.luxpowertek.com/WManage/api/analyze/chart/dayMultiLine";
            string payload = string.Format("serialNum={0}&dateText={1}-{2}-{3}", inverterSerialNUmber, dt.Year, dt.Month, dt.Day);


            string results = Comms.OctopusEnergyWebClient.DoWebRequest(SessionId, url, "POST", payload);
            DayUsageStatisticCollection ret = JsonConvert.DeserializeObject<DayUsageStatisticCollection>(results);
            return ret.data;
        }

        public bool SetForceDischargeTime(string inverterSerialNUmber, int hours, int minutes)
        {
            string url = "https://server.luxpowertek.com/WManage/web/maintain/remoteSet/writeTime";
            string payload = string.Format("inverterSn={0}&timeParam=HOLD_FORCED_DISCHARGE_START_TIME&hour={1}&minute={2}&clientType=WEB&remoteSetType=NORMAL", inverterSerialNUmber, hours, minutes);


            string results = Comms.OctopusEnergyWebClient.DoWebRequest(SessionId, url, "POST", payload);
            OperationResult ret = JsonConvert.DeserializeObject<OperationResult>(results);
            return ret.Result;
        }
    }
}