using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ClassLibrary
{
    public class Class1
    {
        public string BITest() {

            string sql = "SELECT CustomerID, CompanyName FROM Customers";

            return sql;
        }
    }
}
