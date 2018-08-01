using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Conn
    {
        public string connection()
        {
            string connectionname = "Provider=MSDataShape;Data Provider=SQLOLEDB;" +
                   "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=northwind";

            return connectionname;
        }
        
    }
}
