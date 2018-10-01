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
    public class TaxOverallRegionController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();

        public IHttpActionResult Get(string region, string province)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxOverallRegion(region, province));
            return new RawJsonActionResult(jsonString);
        }
    }
}
