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
    public class taxPercentCarController : ApiController
    {
        GaugeProduct tax = new GaugeProduct();
        // GET: api/taxPercentCar
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/taxPercentCar/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxPercentCar(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/taxPercentCar
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/taxPercentCar/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/taxPercentCar/5
        public void Delete(int id)
        {
        }
    }
}
