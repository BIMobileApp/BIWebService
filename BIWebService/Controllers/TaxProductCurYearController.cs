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
    public class TaxProductCurYearController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();

        // GET: api/TaxBudgetYear/
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxCurYear(offcode));
            return new RawJsonActionResult(jsonString);
        }
    }
}
