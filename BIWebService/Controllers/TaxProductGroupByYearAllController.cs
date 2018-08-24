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
    public class TaxProductGroupByYearAllController : ApiController
    {
        TaxProduct tax = new TaxProduct();

        // GET: api/TaxProductGroupByYearAll
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TaxProductGroupByYearAll/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxBudgetProductByYearAll(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/TaxProductGroupByYearAll
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TaxProductGroupByYearAll/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaxProductGroupByYearAll/5
        public void Delete(int id)
        {
        }
    }
}
