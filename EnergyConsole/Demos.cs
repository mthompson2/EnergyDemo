using MarkThompson.Energy.Lux.Inverter.Comms;
using MarkThompson.Energy.Lux.Inverter.CommsObjects;
using MarkThompson.Energy.Lux.Inverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MarkThompson.Energy.Octopus;
using MarkThompson.Energy.Octopus.CommsObjects;


namespace EnergyConsole
{
    public static class Demos
    {
        public static void DoLuxPowerDemo()
        {
            // Enable FIddler Debug Proxy 
            OctopusEnergyWebClient.Proxy = new WebProxy("localhost:8888");

            LuxConfiguration luxConfig = LuxConfiguration.Load();


            // COnnect to Lux Inverter and Query statistics for today#
            LuxInverterClient inverterClient = new LuxInverterClient();
            inverterClient.Authenticate(luxConfig.Username, luxConfig.Password);

            List<PlantInfo> plants = inverterClient.ListPlants();
            PlantInfo plant = plants.First();

            string inverterSerialNumber = inverterClient.ListInverters(plant.Id).First().SerialNum;


            List<DayUsageStatistic> stats = inverterClient.GetStatsForDate(inverterSerialNumber, DateTime.Now);

        }

        public static void DoOctopusDemo()
        {
            // Enable FIddler Debug Proxy 
            OctopusEnergyWebClient.Proxy = new WebProxy("localhost:8888");

            OctoConfiguration config = OctoConfiguration.Load();
            OctopusEnergyClient client = new OctopusEnergyClient();

            IEnumerable<AgilePricing> prices=  client.GetExportPrices(config.APIKey);

            // Remove any prices not for tomorrow (May be past our other future dates)
            IEnumerable<AgilePricing> tomorrowsPrices = prices.Where(x => x.valid_from.Date == DateTime.Now.AddDays(1).Date);
            
            /** Returns the first time with the best price.  Bear in mind there may be multiple times when the best price is achieved (Often occurs) **/
            AgilePricing bestPrice = tomorrowsPrices.Last(x => x.value_exc_vat == tomorrowsPrices.Max(x => x.value_exc_vat));


            Console.Write($"Best Price of {bestPrice.value_exc_vat}p is at {bestPrice.valid_to.ToShortTimeString()}");
        }
    }
}
