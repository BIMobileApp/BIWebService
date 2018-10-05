using BILibraryBLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BIWebService.Controllers
{
    public class dllMMonthController : ApiController
    {
        DDLMaster sql = new DDLMaster();
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(sql.MMonth());
            return new RawJsonActionResult(jsonString);
        }
    }
}
