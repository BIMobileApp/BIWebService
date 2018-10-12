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
        public IHttpActionResult Get(string offcode, string month_from, string month_to, string Region, string Province)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxBudgetRegByMth(offcode, month_from, month_to, Region, Province));
            return new RawJsonActionResult(jsonString);
        }

    }
}
