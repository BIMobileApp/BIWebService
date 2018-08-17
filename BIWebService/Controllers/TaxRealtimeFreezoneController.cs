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
    public class TaxRealtimeFreezoneController : ApiController
    {
        TaxRealtime tax = new TaxRealtime();
        // GET: api/TaxRealtimeFreezone
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TaxRealtimeFreezone/5
        public IHttpActionResult Get(string month)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxRealtimeFreezone(month));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/TaxRealtimeFreezone
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TaxRealtimeFreezone/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaxRealtimeFreezone/5
        public void Delete(int id)
        {
        }
    }
}
