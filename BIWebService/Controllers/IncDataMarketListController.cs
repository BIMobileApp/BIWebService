using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BILibraryBLL;
using Newtonsoft.Json;

namespace BIWebService.Controllers
{
    public class IncDataMarketListController : ApiController
    {
        IncDataMarket tax = new IncDataMarket();

        public IHttpActionResult Get(string offcode, string province, string region)
        {
            var jsonString = JsonConvert.SerializeObject(tax.IncDataMarketList(offcode, province, region));
            return new RawJsonActionResult(jsonString);
        }
    }
}
