using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BIWebService.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get()
        {

            string conn = "Provider=OraOLEDB.Oracle;" +
                          "Data Source=192.168.41.101:1521/XE;User Id=ed_target;Password=oracle";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                Console.WriteLine("ConnectionString = {0}\n", conn);
                Console.WriteLine("State = {0}", connection.State);
                Console.WriteLine("DataSource = {0}", connection.DataSource);
                Console.WriteLine("ServerVersion = {0}", connection.ServerVersion);
            }


            return "";
            //return new string[] { "value1", "value2" };
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
