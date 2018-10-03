using BILibraryBLL;
using ClassLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BIWebService.Controllers
{
    public class MapColorThailandController : ApiController
    {
        MapColor map = new MapColor();

        public IHttpActionResult Get(string budget_year)
        {
            var jsonString = JsonConvert.SerializeObject(map.MapColorThailand(budget_year));
            return new RawJsonActionResult(jsonString);
        }
    }
}
