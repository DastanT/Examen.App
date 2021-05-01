using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices.Lib
{
    public class Computer : IDevice
    {
        public int Id { get; set; }
        public DateTime ProdDate { get; set; }
        public int WarrantyInMonths { get; set; }
        public int DepartmentId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Os { get; set; }

        public Computer()
        {

        }

    }
}
