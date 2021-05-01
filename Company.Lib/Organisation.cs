using Depart.Lib;
using Devices.Lib;
using Person.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Company.Lib
{

    public class Organisation : ICompanys
    {
        public int Id { get; set; }
        public string OrganisationName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        //public List<IDepartment> departs = new List<IDepartment>();

        //public List<IPerson> employees = new List<IPerson>();

        //public List<IDevice> devices = new List<IDevice>();

        public List<Department> departs = new List<Department>();

        public List<Employee> employees = new List<Employee>();

        public List<Computer> devices = new List<Computer>();

        public List<Repair> repairs = new List<Repair>();


        //public List<IDepartment> depart { get; set; }
        //public List<IPerson> employee { get; set; }
        //public List<IDevice> device { get; set; }

        public List<Department> depart { get; set; }
        public List<Employee> employee { get; set; }
        public Organisation()
        {

        }
        public Organisation(int id, string organisationName, string adress, string phoneNumber)
        {
            this.Id = id;
            this.OrganisationName = organisationName;
            this.Address = adress;
            this.PhoneNumber = phoneNumber;
        }


        public void PrintInfo()
        {
            Console.WriteLine($"Id: {Id}\n" +
                $"Company: {OrganisationName}\n" +
                $"Address: {Address}\n" +
                $"Phone: {PhoneNumber}");
            foreach (Department dep in departs)
            {
                Console.WriteLine($"Department Id: {dep.Id}\n" +
                    $"Department: {dep.Name}");
            }
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"Employee: {emp.FirstName} {emp.LastName}");
            }
            foreach (Computer comp in devices)
            {
                Console.WriteLine($"Device Id: {comp.Id}\n" +
                    $"Model: {comp.Name}\n" +
                    $"Operation system: {comp.Os}\n" +
                    $"Purchase date: {comp.ProdDate.ToString("dd.MM.yyyy")}\n" +
                    $"Warranty: {comp.WarrantyInMonths}");
            }
            foreach (Repair rep in repairs)
            {
                Console.WriteLine($"Work: {rep.Work}\n" +
                    $"Cost: {rep.Price}\n" +
                    $"Date of work: {rep.startWarrantyDate.ToString("dd.MM.yyyy")}\n" +
                    $"Warranty for work: {rep.WarrantyForWork}");
            }


        }

    

    }
}
