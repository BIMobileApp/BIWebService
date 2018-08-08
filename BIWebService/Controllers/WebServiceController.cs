using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using BILibraryBLL;
using ClassLib;
using Newtonsoft.Json;

namespace BIWebService.Controllers
{
    public class WebServiceController : ApiController
    {
        ConnectionStringTest con = new ConnectionStringTest();
        GaugeAllmthSectionSQL dt = new GaugeAllmthSectionSQL();

        //Get Api
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(dt.SQL1());
            return new RawJsonActionResult(jsonString);
        }

        // Get Json 2 Dimention same array 2 dimention
       /* public string DataTableToJSONWithJavaScriptionSerializer(DataTable table)
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
            }
            return 
        }
        */

    }
}
