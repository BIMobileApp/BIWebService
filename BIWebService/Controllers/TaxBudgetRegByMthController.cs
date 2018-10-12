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
    public class TaxBudgetRegByMthController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();
 
        // GET: api/TaxBudgetRegByMth/5
        public IHttpActionResult Get(string offcode, string month_from, string month_to, string region, string province)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxBudgetRegByMth(offcode, month_from, month_to, region, province));
            return new RawJsonActionResult(jsonString);
        }

    }
}
