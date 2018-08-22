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
    public class FollowPayTaxRealtimeAllController : ApiController
    {
        TaxRealtime tax = new TaxRealtime();
        // GET: api/FollowPayTaxRealtimeAll
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FollowPayTaxRealtimeAll/5
        public IHttpActionResult Get(string year)
        {
            var jsonString = JsonConvert.SerializeObject(tax.FollowPayTaxRealtimeAll(year));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/FollowPayTaxRealtimeAll
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FollowPayTaxRealtimeAll/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FollowPayTaxRealtimeAll/5
        public void Delete(int id)
        {
        }
    }
}
