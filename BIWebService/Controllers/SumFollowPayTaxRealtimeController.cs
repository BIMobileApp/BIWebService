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
    public class SumFollowPayTaxRealtimeController : ApiController
    {
        TaxRealtime tax = new TaxRealtime();

        public IHttpActionResult Get(string offcode, string region, string province)
        {
            var jsonString = JsonConvert.SerializeObject(tax.SumFollowPayTaxRealtime(offcode, region, province));
            return new RawJsonActionResult(jsonString);
        }

    }
}
