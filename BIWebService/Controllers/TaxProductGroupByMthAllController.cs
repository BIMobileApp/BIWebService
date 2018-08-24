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
    public class TaxProductGroupByMthAllController : ApiController
    {
        TaxProduct tax = new TaxProduct();
        // GET: api/TaxProductGroupByMthAll
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TaxProductGroupByMthAll/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxBudgetProductByMthAll(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/TaxProductGroupByMthAll
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TaxProductGroupByMthAll/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaxProductGroupByMthAll/5
        public void Delete(int id)
        {
        }
    }
}
