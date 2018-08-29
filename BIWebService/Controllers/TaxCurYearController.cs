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
    public class TaxCurYearController : ApiController
    {
       
        TaxBudgetYear tax = new TaxBudgetYear();

        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(tax.getTaxCurYear());
            return new RawJsonActionResult(jsonString);
        }
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxCurYearAll(offcode));
            return new RawJsonActionResult(jsonString);
        }

    }
}
