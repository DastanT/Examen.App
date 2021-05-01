using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Lib
{
    public class Client : ICompanys
    {
        public int Id { get; set; }
        public string OrganisationName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
