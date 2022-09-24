using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkThompson.Energy.Octopus.CommsObjects
{
    public class AgilePricing
    {
        public double value_exc_vat { get; set; }
        public double value_inc_vat { get; set; }
        public DateTime valid_from { get; set; }
        public DateTime valid_to { get; set; }
    }

    public class AgilePricingCollection
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<AgilePricing> results { get; set; }
    }




}
