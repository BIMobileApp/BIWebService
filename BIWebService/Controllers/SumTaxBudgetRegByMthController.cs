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
    public class SumTaxBudgetRegByMthController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();
        // GET: api/SumTaxBudgetRegByMth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SumTaxBudgetRegByMth/5
        public string Get(int id)
        {           
            var jsonString = JsonConvert.SerializeObject(tax.SumTaxBudgetRegByMth(id));
            return jsonString;
        }

        // POST: api/SumTaxBudgetRegByMth
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SumTaxBudgetRegByMth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SumTaxBudgetRegByMth/5
        public void Delete(int id)
        {
        }
    }
}
