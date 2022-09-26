namespace EnergyWebAppGcp.Models
{
    public class EnergyPriceModel
    {
        public IEnumerable<MarkThompson.Energy.Octopus.CommsObjects.AgilePricing> Prices { get; set; }
    }
}
