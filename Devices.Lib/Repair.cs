using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices.Lib
{
    public class Repair
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string Work { get; set; }
        public int WarrantyForWork { get; set; }
        public decimal Price { get; set; }
        public string DeviceName { get; set; }
        public DateTime startWarrantyDate { get; set; }
    }
}
