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
    public class TaxCurYearbyYearController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();

        public IHttpActionResult Get(string offcode, string year)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxCurYearbyYear(offcode, year));
            return new RawJsonActionResult(jsonString);
        }
    }
}
