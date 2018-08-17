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
    public class TaxProductGroupSourceController : ApiController
    {
        TaxProduct tax = new TaxProduct();
        // GET: api/TaxProductGroupSource
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxProductGroupSource());
            return new RawJsonActionResult(jsonString);
        }

        // GET: api/TaxProductGroupSource/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TaxProductGroupSource
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TaxProductGroupSource/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaxProductGroupSource/5
        public void Delete(int id)
        {
        }
    }
}
