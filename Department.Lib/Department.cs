using Person.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depart.Lib
{
    public class Department:IDepartment
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; }

        public Department()
        {

        }

        public Department(int id, int orgsId, string name)
        {
            this.Id = id;
            this.OrganizationId = orgsId;
            this.Name = name;
        }


    }
}
