using BILibraryBLL;
using ClassLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace BIWebService.Controllers
{
    public class newReportLineFollowProdController : ApiController
    {
        Conn con = new Conn();
        newReportLineFollowProdSQL dt = new newReportLineFollowProdSQL();

        //Get Api
        public IHttpActionResult Get(string id)
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var jsonString = JsonConvert.SerializeObject(dt.SQL1(id));
            return new RawJsonActionResult(jsonString.ToLower());
        }
    }
}
