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
    public class taxPercentSuraController : ApiController
    {
        GaugeProduct tax = new GaugeProduct();
        // GET: api/taxPercentSura
        public  string Get()
        {            
            return "value";
        }

        // GET: api/taxPercentSura/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxPercentSura(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/taxPercentSura
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/taxPercentSura/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/taxPercentSura/5
        public void Delete(int id)
        {
        }
    }
}
