using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkThompson.Energy.Lux.Inverter.CommsObjects
{
    public class InverterInfo
    {
        public int Phase { get; set; }
        public int DeviceType { get; set; }
        public string SerialNum { get; set; }
        public string FwCode { get; set; }
        public string WarrantyExpireDate { get; set; }
        public string DeviceTypeText { get; set; }
        public int PlantId { get; set; }
        public int SubDeviceType { get; set; }
        public int ServerId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string SohText { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public int PowerRating { get; set; }
        public int Dtc { get; set; }
        public string EndUser { get; set; }
        public bool ParallelEnabled { get; set; }
        public bool Lost { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string DatalogSn { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public int Model { get; set; }
        public int BatParallelNum { get; set; }
        public string CommissionDate { get; set; }
        public int BatCapacity { get; set; }
        public string PlantName { get; set; }
        public int Status { get; set; }
        public string LastUpdateTime { get; set; }
        public int BatteryTotalWh
        {
            get
            {
                return BatCapacity * BatParallelNum;
            }
        }
    }
}
