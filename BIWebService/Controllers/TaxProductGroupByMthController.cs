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
    public class TaxProductGroupByMthController : ApiController
    {
        TaxProduct tax = new TaxProduct();
        // GET: api/TaxProductGroupByMth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TaxProductGroupByMth/5
        public IHttpActionResult Get(string offcode, string area, string province,string monthFrom , string monthTo)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxBudgetProductByMth(offcode, area, province, monthFrom, monthTo));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/TaxProductGroupByMth
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TaxProductGroupByMth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaxProductGroupByMth/5
        public void Delete(int id)
        {
        }
    }
}
