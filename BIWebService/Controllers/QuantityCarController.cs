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
    public class QuantityCarController : ApiController
    {
        GaugeProduct tax = new GaugeProduct();
        // GET: api/QuantityCar
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/QuantityCar/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.QuantityPercentSura(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/QuantityCar
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/QuantityCar/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/QuantityCar/5
        public void Delete(int id)
        {
        }
    }
}
