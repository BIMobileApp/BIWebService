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
using BILibraryBLL;
using ClassLib;


namespace BIWebService.Controllers
{

    public class TestController : ApiController
    {
        Conn con = new Conn();
        TestSql dt = new TestSql();

        // GET: api/Test

        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(dt.Sql1());
            return new RawJsonActionResult(jsonString);
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
        public void Post(string id, string name)
        {
            dt.testInsertData(id, name);
        }

        // PUT: api/Test/5
        public void Put(string id, string name)
        {
            dt.testUpdateData(id, name);           
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
