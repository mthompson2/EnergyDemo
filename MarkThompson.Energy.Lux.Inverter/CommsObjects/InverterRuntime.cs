using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkThompson.Energy.Lux.Inverter.CommsObjects
{

    public class InverterRuntime
    {
        #region Solar
        /*** SOLAR Props **/
        [JsonProperty("vpv1")]
        public int SolarStringVoltage1 { get; set; } // Solar String Voltage (Multiplied by 10)


        [JsonProperty("vpv2")]
        public int SolarStringVoltage2 { get; set; } // Solar String Voltage (Multiplied by 10)


        [JsonProperty("vpv3")]
        public int SolarStringVoltage3 { get; set; } // Solar String Voltage (Multiplied by 10)


        [JsonProperty("ppv1")]
        public int SolarStringPower1 { get; set; }

        [JsonProperty("ppv2")]
        public int SolarStringPower2 { get; set; }

        [JsonProperty("ppv3")]
        public int SolarStringPower3 { get; set; }
        #endregion // Solar

        #region Battery
        /*** Battery Props ***/
        [JsonProperty("pDisCharge")]
        public int BatteryDischargePower { get; set; }


        [JsonProperty("batteryType")]
        public string BatteryType { get; set; }


        [JsonProperty("vBat")]
        public int  BatteryVoltage{ get; set; }


        [JsonProperty("pCharge")]
        public int BatteryChargingPower { get; set; }

        [JsonProperty("soc")]
        public int BatteryChargePercentage { get; set; }

        #endregion // Battery



        #region Grid
        /*** Grid Props ***/
        [JsonProperty("fac")]
        public int GridFrequency { get; set; } // Hz multipled by 100


        [JsonProperty("vepsr")]
        public int GridACVOltage { get; set; } /* Voltage is mutiplied by 10 */


        [JsonProperty("pToGrid")]
        public int GridPowerSend { get; set; }


        [JsonProperty("pToUser")]
        public int  GridPowerReceive{ get; set; }


        #endregion //Grid


        #region Inverter
        /*** Inverter Props ***/

        [JsonProperty("deviceTime")]
        public string InverterTime { get; set; }


        [JsonProperty("tinner")]
        public int InverterTemperatureInner { get; set; }


        [JsonProperty("tradiator1")]
        public int InverterTemperatureRadiator1 { get; set; }


        [JsonProperty("tradiator2")]
        public int InverterTemperatureRadiator2 { get; set; }


        [JsonProperty("serialNum")]
        public string SerialNumber { get; set; } // Also station id

        [JsonProperty("statusText")]
        public string Status { get; set; }

        #endregion //Inverter


        #region LeftOver

        public bool hasRuntimeData { get; set; }


        public int peps { get; set; }



        public int prec { get; set; }
        public bool lost { get; set; }
        public int vBus2 { get; set; }
        public int vBus1 { get; set; }
        public string serverTime { get; set; }
        public int seps { get; set; }


        public string fwCode { get; set; }
        public int remainTime { get; set; }
        public int vact { get; set; }
        public int vacs { get; set; }
        public int vepst { get; set; }
        public int vacr { get; set; }
        public int feps { get; set; }





        public int vepss { get; set; }

        public int tBat { get; set; }
        public int pinv { get; set; }
        public int maxChgCurr { get; set; }
        public bool success { get; set; }
        public string pf { get; set; }

        public string batteryColor { get; set; }





        public int maxDischgCurr { get; set; }

        #endregion //LeftOver




    }

}
