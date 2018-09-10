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
    public class TaxProvinceCurYearController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();
        public IHttpActionResult Get(string area)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxProvinceCurYear(area));
            return new RawJsonActionResult(jsonString);
        }
    }
}
