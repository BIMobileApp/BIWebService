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
    public class TaxBudgetRegByMthAllController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();

        // GET: api/TaxBudgetRegByMthAll
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TaxBudgetRegByMthAll/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxBudgetRegByMthAll(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/TaxBudgetRegByMthAll
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TaxBudgetRegByMthAll/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaxBudgetRegByMthAll/5
        public void Delete(int id)
        {
        }
    }
}
