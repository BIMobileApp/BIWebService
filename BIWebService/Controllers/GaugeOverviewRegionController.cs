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
    public class GaugeOverviewRegionController : ApiController
    {
        GuageOverviewRegion sql = new GuageOverviewRegion();
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(sql.GuageMonth_Region(offcode));
            return new RawJsonActionResult(jsonString);
        }
    }
}
