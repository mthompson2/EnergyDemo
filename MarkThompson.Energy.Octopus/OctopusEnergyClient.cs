using Newtonsoft.Json;

namespace MarkThompson.Energy.Octopus
{
    public class OctopusEnergyClient
    {
        public IEnumerable<CommsObjects.AgilePricing> GetExportPrices(string apiKey)
        {
            string str = Comms.OctopusEnergyWebClient.DoWebRequest(apiKey, "https://api.octopus.energy/v1/products/AGILE-OUTGOING-19-05-13/electricity-tariffs/E-1R-AGILE-OUTGOING-19-05-13-C/standard-unit-rates/");

            CommsObjects.AgilePricingCollection result = JsonConvert.DeserializeObject<CommsObjects.AgilePricingCollection>(str);
            return result.results;
        }
    }
}