using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdcModel.DbModel.SecurityModule
{
    public class CityDbModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
        }


        private int countyId;

        public int CountryId
        {
            get { return countyId; }
            set { countyId = value; }
        }








    }
}
