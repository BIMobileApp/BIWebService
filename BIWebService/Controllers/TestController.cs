using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Web.Mvc;
using ClassLib;
using BILibraryBLL;

namespace BIWebService.Controllers
{

    public class TestController : ApiController
    {
        Conn con = new Conn();

        // GET: api/Test

        public IHttpActionResult Get()
        {
            /*using(OleDbConnection connection = new OleDbConnection(
                    "Provider=MSDataShape;Data Provider=SQLOLEDB;" +
                    "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=northwind"))
            {
                OleDbCommand custCMD = new OleDbCommand(
                  "SHAPE {SELECT CustomerID, CompanyName FROM Customers} " +
                  "APPEND ({SELECT CustomerID, OrderID FROM Orders} AS CustomerOrders " +
                  "RELATE CustomerID TO CustomerID)", connection);

                connection.Open();

                OleDbDataReader custReader = custCMD.ExecuteReader();
                OleDbDataReader orderReader;*/

            TestSql dt = new TestSql();

            var jsonString = JsonConvert.SerializeObject(dt.Sql1());
            return new RawJsonActionResult(jsonString);


            /*System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
                return Regex.Replace(serializer.Serialize(rows), @"[^\x20-\x7F]", ""); ;
            }*/

            // while (custReader.Read())
            //{


            /*Console.WriteLine("Orders for " + custReader.GetString(1));
            // custReader.GetString(1) = CompanyName  

            orderReader = (OleDbDataReader)custReader.GetValue(2);
            // custReader.GetValue(2) = Orders chapter as DataReader  

            while (orderReader.Read())
                Console.WriteLine("\t" + orderReader.GetInt32(1));
            // orderReader.GetInt32(1) = OrderID  
       //}
        // Make sure to always close readers and connections.  
        //custReader.Close();
    / }

    /*using (connection)
    {
        SqlCommand command = new SqlCommand(
          "SELECT CategoryID, CategoryName FROM Categories;",
          connection);
        connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                    reader.GetString(1));
            }
        }
        else
        {
            Console.WriteLine("No rows found.");
        }
        reader.Close();
    }*/

            //return new string[] { "value1", "value2" };


            /*public void CreateMyOracleDataReader(string connectionString)
            {

                string queryString = "";

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    OracleCommand command = new OracleCommand(queryString, connection);
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetValue(0));
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }

            public static void CreateOracleConnection()
            {
                string connectionString = "Data Source=Oracle8i;Integrated Security=yes";
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("ServerVersion: " + connection.ServerVersion
                        + "\nDataSource: " + connection.DataSource);
                }
            }*/
        }

        public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }

        // GET: api/Test/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
