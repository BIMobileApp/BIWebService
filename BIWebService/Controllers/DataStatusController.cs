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
    public class DataStatusController : ApiController
    {
        DataStatus tax = new DataStatus();
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(tax.getDataStatus());
            return new RawJsonActionResult(jsonString);
        }
    }
}
