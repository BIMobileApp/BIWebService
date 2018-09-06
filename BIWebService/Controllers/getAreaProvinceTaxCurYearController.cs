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
    public class getAreaProvinceTaxCurYearController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.getAreaTaxCurYear(offcode));
            return new RawJsonActionResult(jsonString);
        }
        public IHttpActionResult Get(string offcode,string area)
        {
            var jsonString = JsonConvert.SerializeObject(tax.getProvinceTaxCurYear(offcode,area));
            return new RawJsonActionResult(jsonString);
        }
    }
}
