using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BILibraryBLL;

namespace BIWebService.Controllers
{
    public class TaxBudgetYearController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();
        // GET: api/TaxBudgetYear
        public string Get()
        {
            return "";
        }

        // GET: api/TaxBudgetYear/5
        public IHttpActionResult Get(string year)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxBudgetOnYear(year));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/TaxBudgetYear
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TaxBudgetYear/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaxBudgetYear/5
        public void Delete(int id)
        {
        }
    }
}
