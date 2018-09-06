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
    public class TaxRealtimeDailyController : ApiController
    {
        TaxRealtime tax = new TaxRealtime();

        // GET: api/FollowPayTaxRealtimeAll/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxRealtimeDaily(offcode));
            return new RawJsonActionResult(jsonString);
        }

    }
}
