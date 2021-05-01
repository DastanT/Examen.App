using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDb.DataBase
{
    public class LiteDatBase
    {
        private string ConnectionDb { get; set; }


        public LiteDatBase(string pathToDb)
        {
            if (string.IsNullOrEmpty(pathToDb))
                throw new Exception("Укажите корректный путь");
            else
                ConnectionDb = pathToDb;
        }



    }
}
