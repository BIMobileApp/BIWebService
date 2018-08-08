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
    public class TaxBudgetProductController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();
        // GET: api/TaxBudgetProduct
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxBudgetProduct());
            return new RawJsonActionResult(jsonString);
        }

        // GET: api/TaxBudgetProduct/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TaxBudgetProduct
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TaxBudgetProduct/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaxBudgetProduct/5
        public void Delete(int id)
        {
        }
    }
}
