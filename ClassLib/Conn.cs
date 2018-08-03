using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Conn
    {
        public string connection() {
            /*string conn = "Provider=MSDataShape;Data Provider=SQLOLEDB;" +
                          "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=northwind";

             string conn = "Provider=MSDataShape;Data Provider=SQLOLEDB;" +
                           "Data Source=192.168.41.101;" +
                           "Initial Catalog=EDBI_DEV;User Id=ed_target;Password=oracle;";*/

            string conn = "Data Source=(DESCRIPTION="
             + "(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.41.101)(PORT=1521))"
             + "(CONNECT_DATA=(SERVICE_NAME=EDBI)));"
             + "User Id=ed_target;Password=oracle;Provider=Oracle.DataAccess.Client;";



            return conn;
        }
    }
}
