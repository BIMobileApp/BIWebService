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
    public class CompareTaxVolProductController : ApiController
    {
        CompareTax tax = new CompareTax();

        // GET: api/TaxBudgetRegAll/5

        public IHttpActionResult Get(string offcode, string region, string province, string month_from, string month_to, string dbtable)
        {
            var jsonString = JsonConvert.SerializeObject(tax.CompareTaxVolProduct(offcode, region, province, month_from, month_to, dbtable));
            return new RawJsonActionResult(jsonString);
        }
    }
   
}
