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
    public class TaxProductGroupByYearController : ApiController
    {
        TaxProduct tax = new TaxProduct();
        // GET: api/TaxProductGroupByYear
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TaxProductGroupByYear/5
        public IHttpActionResult Get(string year)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxBudgetProductByYear(year));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/TaxProductGroupByYear
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TaxProductGroupByYear/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaxProductGroupByYear/5
        public void Delete(int id)
        {
        }
    }
}
