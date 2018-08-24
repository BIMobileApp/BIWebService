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
    public class QuantitySuraController : ApiController
    {
        GaugeProduct tax = new GaugeProduct();
        // GET: api/QuantitySura
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/QuantitySura/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.QuantityPercentSura(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/QuantitySura
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/QuantitySura/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/QuantitySura/5
        public void Delete(int id)
        {
        }
    }
}
