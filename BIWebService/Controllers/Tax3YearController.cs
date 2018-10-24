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
    public class Tax3YearController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(tax.Tax3YearHeader());
            return new RawJsonActionResult(jsonString);
        }
        public IHttpActionResult Get(string area, string province)
        {
            var jsonString = JsonConvert.SerializeObject(tax.Tax3Year(area, province));
            return new RawJsonActionResult(jsonString);
        }
    }
}
