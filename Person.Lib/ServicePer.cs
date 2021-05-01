using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Lib
{
    public class ServicePer
    {

        private DirectoryInfo rootDir = null;
        private string pathTo;

        RestClient client = new RestClient("https://randomuser.me/");
        RestRequest request = new RestRequest("api/?nat=us&randomapi");


        private bool GetData(out string result)
        {
            result = "";
            try
            {
                IRestResponse response = client.Get(request);

                if (response.IsSuccessful)
                {
                    result = response.Content;

                    if (!string.IsNullOrWhiteSpace(result))
                        return true;
                    else
                        return false;
                }
                else
                {
                    result = "";
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Employee GetEmployee()
        {
            Employee employee = null;
            string result = "";
            if (GetData(out result))
            {
                var data = JsonConvert.DeserializeObject<data>(result);
                employee = (Employee)data;
            }
            return employee;
        }

        public ServicePer()
        {

        }
        public ServicePer(string rootPath)
        {
            if (string.IsNullOrWhiteSpace(rootPath))
                throw new Exception("Укажите корректный путь.");

            rootDir = new DirectoryInfo(rootPath);

            if (!rootDir.Exists)
                rootDir.Create();

            pathTo = Path.Combine(rootDir.FullName, "data.xml");
        }

    }
    public class data
    {
        public List<Results> results { get; set; }

        public static explicit operator Employee(data dat)
        {
            Employee employee = new Employee();
            employee.Id = dat.results[0].id.value;
            employee.FirstName = dat.results[0].name.first;
            employee.LastName = dat.results[0].name.last;
            employee.Dob = dat.results[0].dob.date;
            employee.Gender = dat.results[0].gender;

            return employee;
        }
    }

    public class Results
    {
        public string gender { get; set; }
        public id id { get; set; }
        public name name { get; set; }
        public dob dob { get; set; }


    }

    public class id
    {
        public string value { get; set; }
    }
    public class name
    {
        public string first { get; set; }
        public string last { get; set; }
    }
    public class dob
    {
        public DateTime date { get; set; }
    }
}
