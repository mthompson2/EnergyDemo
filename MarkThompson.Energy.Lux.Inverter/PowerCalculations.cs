using MarkThompson.Energy.Lux.Inverter.CommsObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkThompson.Energy.Lux.Inverter
{
    public class PowerCalculations
    {
        private InverterRuntime _rt;

        public PowerCalculations(InverterRuntime rt)
        {
            _rt = rt;

        }


        public int TotalSolarPower
        {
            get
            {
                return _rt.SolarStringPower1 + _rt.SolarStringPower2 + _rt.SolarStringPower3;
            }
        }

        public bool IsUsingGridPower
        {
            get
            {
                return _rt.GridPowerReceive > 0;
            }
        }




    }
}
