using Person.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depart.Lib
{
    public interface IDepartment
    {
        int Id { get; set; }
        int OrganizationId { get; set; }
        string Name { get; set; }
    }
}
