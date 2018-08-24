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
    public class QuantityBeerController : ApiController
    {
        GaugeProduct tax = new GaugeProduct();
        // GET: api/QuantityBeer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/QuantityBeer/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.QuantityPercentBeer(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/QuantityBeer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/QuantityBeer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/QuantityBeer/5
        public void Delete(int id)
        {
        }
    }
}
