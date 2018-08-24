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
    public class TaxBudgetRegAllController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();
        // GET: api/TaxBudgetRegAll
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TaxBudgetRegAll/5
        public IHttpActionResult Get(string offcode,string group_id)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxBudgetRegAll(offcode, group_id));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/TaxBudgetRegAll
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TaxBudgetRegAll/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaxBudgetRegAll/5
        public void Delete(int id)
        {
        }
    }
}
