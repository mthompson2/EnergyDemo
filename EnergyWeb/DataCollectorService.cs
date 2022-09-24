using MarkThompson.Energy.Lux.Inverter;
using MarkThompson.Energy.Lux.Inverter.CommsObjects;
using MarkThompson.Energy.Octopus;
using MarkThompson.Energy.Octopus.CommsObjects;
using System.Net;

namespace EnergyWeb
{
    public class DataCollectorService
    {
        public List<DayUsageStatistic> DoLuxPowerDemo()
        {
    
            LuxConfiguration luxConfig = LuxConfiguration.Load();


            // COnnect to Lux Inverter and Query statistics for today#
            LuxInverterClient inverterClient = new LuxInverterClient();
            inverterClient.Authenticate(luxConfig.Username, luxConfig.Password);

            List<PlantInfo> plants = inverterClient.ListPlants();
            PlantInfo plant = plants.First();

            string inverterSerialNumber = inverterClient.ListInverters(plant.Id).First().SerialNum;


            List<DayUsageStatistic> stats = inverterClient.GetStatsForDate(inverterSerialNumber, DateTime.Now);
            return stats;
        }

        public IEnumerable<AgilePricing> GetAgilePrices()
        {
    
            OctoConfiguration config = OctoConfiguration.Load();
            OctopusEnergyClient client = new OctopusEnergyClient();

            IEnumerable<AgilePricing> prices = client.GetExportPrices(config.APIKey);

            // Remove any prices not for tomorrow (May be past our other future dates)
            IEnumerable<AgilePricing> tomorrowsPrices = prices.Where(x => x.valid_from.Date == DateTime.Now.AddDays(1).Date);

            return tomorrowsPrices;
        }
    }
}
