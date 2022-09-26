using MarkThompson.Energy.Lux.Inverter.Comms;
using MarkThompson.Energy.Octopus;
using MarkThompson.Energy.Octopus.CommsObjects;
using System.Net;

namespace EnergyWebAppGcp.Services
{
    public class EnergyService
    {
        public IEnumerable<AgilePricing> GetPricesForNextDay()
        {
             OctopusEnergyClient client = new OctopusEnergyClient();

            IEnumerable<AgilePricing> prices = client.GetExportPrices(Secrets.AppSecrets.OctopusKey);

            // Remove any prices not for tomorrow (May be past our other future dates)
            IEnumerable<AgilePricing> nextDayPrices = prices.Where(x => x.valid_from.Date == DateTime.Now.AddDays(1).Date);

            nextDayPrices = nextDayPrices.OrderBy(x => x.valid_from);

            return nextDayPrices;

        }
    }
}
