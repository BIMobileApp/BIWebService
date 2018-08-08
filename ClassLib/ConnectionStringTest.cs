using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class ConnectionStringTest
    {
        public string connection()
        {
            /*string conn = "Data Source=(DESCRIPTION="
             + "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))"
             + "(CONNECT_DATA=(SERVICE_NAME=XE)));"
             + "User Id=ed_target;Password=ed_target;Provider=OraOLEDB.Oracle;OLEDB.NET=True;";*/


            String conn = "Data Source=(DESCRIPTION=" +
                "(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.41.101)(PORT=1521))" +
                "(CONNECT_DATA=(SERVICE_NAME=EDBI)));" +
                "User Id=ed_target;Password=oracle;Provider=OraOLEDB.Oracle;OLEDB.NET=True;";

            return conn;
        }
    }
}
