using MarkThompson.Energy.Octopus.CommsObjects;

namespace EnergyWeb.Models
{
    public class ExportPriceModel
    {
        public IEnumerable<AgilePricing> Pricing{get;set;}
    }
}
