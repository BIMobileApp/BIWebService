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

        public IHttpActionResult Get(string offcode,string month_from, string month_to)
        {
            var jsonString = JsonConvert.SerializeObject(tax.IncSumDataMarketList(offcode, month_from, month_to));
            return new RawJsonActionResult(jsonString);
        }
    }
}
