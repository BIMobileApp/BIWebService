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

        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(tax.getProductCurYear());
            return new RawJsonActionResult(jsonString);
        }
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxProductCurYearAll(offcode));
            return new RawJsonActionResult(jsonString);
        }
    }
}
