using Depart.Lib;
using Devices.Lib;
using Person.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Company.Lib
{
    public class ServiceCompany
    {

        ServicePer db = new ServicePer(@"Datbase.db");
        Organisation organisation = new Organisation();
        public List<Organisation> organisations { get; set; }
        public ServiceCompany()
        {

        }

        public ServiceCompany(Organisation organisation)
        {
            this.organisation = organisation;
        }

        public void AttachDepartment(Organisation org, int orgId, Department dep)
        {
            organisations = new List<Organisation>();
            organisations.Add(org);
            foreach (Organisation item in organisations)
            {
                if (item.Id == orgId)
                {
                    item.departs.Add(dep);
                }
            }
        }

        public void AttachEmployee(Organisation org, int id, Employee emp)
        {
            organisations = new List<Organisation>();
            organisations.Add(org);
            foreach (Organisation item in organisations)
            {
                if (item.Id == id)
                {
                    item.employees.Add(emp);
                }
            }
        }

        public void AttachDevice(Organisation org, int idDepart, Computer comp)
        {
            organisation = new Organisation();
            {
                foreach (Organisation item in organisations)
                {
                    foreach (Department deps in item.departs)
                    {
                        if (deps.Id == idDepart)
                        {
                            item.devices.Add(comp);
                        }
                    }
                }
            }
        }

        public void AttachRepair(Organisation org, int idDev, Repair rep)
        {
            organisation = new Organisation();
            {
                foreach (Organisation item in organisations)
                {
                    foreach (Computer comps in item.devices)
                    {
                        if (comps.Id == idDev)
                        {
                            item.repairs.Add(rep);
                        }
                    }
                }
            }
        }
        public Organisation initOrganisation(Organisation obj)
        {
            Organisation org = new Organisation();
            org.Id = obj.Id;
            org.OrganisationName = obj.OrganisationName;
            org.Address = obj.Address;
            org.PhoneNumber = obj.PhoneNumber;
            org.depart = obj.depart;
            org.employee = obj.employee;
            return org;
        }





        public ServiceCompany(string rootPath)
        {
            if (string.IsNullOrWhiteSpace(rootPath))
                throw new Exception("Укажите корректный путь.");

            rootDir = new DirectoryInfo(rootPath);
            if (!rootDir.Exists)
                rootDir.Create();

            pathToList = Path.Combine(rootDir.FullName, "Database.xml");
        }

        private DirectoryInfo rootDir = null;
        private string pathToList;

        public bool CreateOrg(Organisation obj)
        {
            try
            {
                //1. Создаем директорию Users
                DirectoryInfo orgDir = rootDir.CreateSubdirectory("Company");

                //2. Путь к файлу с данными о пользователе
                string path = Path.Combine(orgDir.FullName, obj.Id + ".xml");

                //3. Производим сериализацию
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Organisation));
                    xmlSerializer.Serialize(fs, organisation);
                }

                //4. Добавлем в список пользователей, вновь добавленного пользователя
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void AddElement<T>(T obj)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathToList);
            XmlElement newElement = xmlDoc.CreateElement(typeof(T).Name);
            xmlDoc.AppendChild(newElement);
            xmlDoc.Save(pathToList);


        }

        public void ShowElements()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathToList);
            XmlElement xRoot = xmlDoc.DocumentElement;

            foreach (XmlNode xNode in xRoot)
            {
                if (xNode.Attributes.Count > 0)
                {
                    XmlNode attr = xNode.Attributes.GetNamedItem("Id");
                    if (attr != null)
                        Console.WriteLine(attr.Value);
                }
                foreach (XmlNode childnode in xNode.ChildNodes)
                {
                    Console.Write(childnode.Value);
                }
                Console.WriteLine();
            }
        }
    }
}

