using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Lib
{
    public interface ICompanys  
    {
        int Id { get; set; }
        string OrganisationName { get; set; }
        string Address { get; set; }
        string PhoneNumber { get; set; }
    }
}
