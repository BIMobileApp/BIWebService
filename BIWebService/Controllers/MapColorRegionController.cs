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
    public class MapColorRegionController : ApiController
    {
        MapColor map = new MapColor();

        public IHttpActionResult Get(string budget_year, string region)
        {
            var jsonString = JsonConvert.SerializeObject(map.MapColorRegion(budget_year, region));
            return new RawJsonActionResult(jsonString);
        }
    }
}
