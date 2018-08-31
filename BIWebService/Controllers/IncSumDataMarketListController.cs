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
    public class IncSumDataMarketListController : ApiController
    {
        IncDataMarket tax = new IncDataMarket();

        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.IncSumDataMarketList(offcode));
            return new RawJsonActionResult(jsonString);
        }
    }
}
