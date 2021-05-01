using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices.Lib
{
    public interface IDevice
    {
        int Id { get; set; }
        DateTime ProdDate { get; set; }
        int WarrantyInMonths { get; set; }
        int DepartmentId { get; set; }
        string Os { get; set; }
        decimal Price { get; set; }
        string Name { get; set; }
    }
}
