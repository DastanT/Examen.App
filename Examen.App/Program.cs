using Company.Lib;
using Depart.Lib;
using Devices.Lib;
using Person.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Examen.App
{
    class Program
    {
        static void Main(string[] args)
        {

            ServicePer db = new ServicePer(@"Employee.db");
            Random rnd = new Random();

            List<Organisation> organisations = new List<Organisation>();
            Organisation organisation = new Organisation(rnd.Next(1, 1000), "Omega", "Almaty", "+77011111111");
            ServiceCompany servComp = new ServiceCompany(organisation);

            organisation = servComp.initOrganisation(organisation);

            Department department1 = new Department(1, organisation.Id, "Production department");
            Department department2 = new Department(2, organisation.Id, "Purchasing department");
            Department department3 = new Department(2, organisation.Id, "Sales department");

            servComp.AttachDepartment(organisation, organisation.Id, department1);


            Employee employee = db.GetEmployee();
            servComp.AttachEmployee(organisation, organisation.Id, employee);

            Computer computer = new Computer();

            computer.Id = rnd.Next(1, 1000);
            computer.Name = "Asus ROG Strix SCAR III G731GW - H6233T";
            computer.Os = "Windows X Home 64";
            computer.Price = 900000;
            computer.ProdDate = DateTime.Now.AddMonths(-15);
            computer.WarrantyInMonths = 0;
            servComp.AttachDevice(organisation, department1.Id, computer);

            Repair repair = new Repair();
            repair.Id = rnd.Next(20, 1000);
            repair.DeviceName = computer.Name;
            repair.Work = "Замена дисплея";
            repair.Price = 50000;
            repair.startWarrantyDate = DateTime.Now;
            repair.WarrantyForWork = 24;
            servComp.AttachRepair(organisation, computer.Id, repair);


            organisation.PrintInfo();

            ServiceCompany service = new ServiceCompany(@"orgnisation");
            service.CreateOrg(organisation);



            //1.В каком случае вы обязаны объявить класс абстрактным ?
            //В том случае, если хотя бы один метод класса является абстрактным.

            //2.Назовите класс.NET, от которого наследуются все классы ?
            // Object.

            //3.Почему нельзя указать модификатор видимости для методов интерфейса?
            //Потому что методы интерфейса должны быть public

            //4.Можно ли наследовать от нескольких интерфейсов ?
            //Да, можно наследоваться от нескольких интерфейсов, поэтому он и есть интерфейс

            //5.Какое преимущество использования класса System.Text.StringBuilder перед System.String ?
            //StringBuilder хорошо работает с большим количеством строк, а System.String при каждом изменении строки создаётся 
            //новый объект в памяти.

            //6.Чем отличается event от delegate?
            //delegate это указаетель на метод, event это событие, они базируются на делегатах, по существу, event представляет
            //собой автоматическое уведомление о том, что произошло некоторое действие.


            //7.Поддерживает ли C# множественное наследование?
            //Множественное наследование от классво не поддерживает в C#, но поддерживает множественное наследование от интерфейсов

            //8.Кому доступны переменные с модификатором protected на уровне класса?
            //Наследуемым классам

            //9.Наследуются ли переменные с модификатором private?
            //нет, т.к. модификатор является private

            //10.Опишите модификатор “protected internal”
            //Это союз модификаторов protected и internal.
            //internal - модификатор определяет доступность члена во всех файлах сборки и его недоступность за пределами сборки.
            //поэтому protected internal -  член, объявленный как protected internal, доступен лишь в пределах собственной
            //сборки или для производных типов.

















            return;
        }
    }
}
