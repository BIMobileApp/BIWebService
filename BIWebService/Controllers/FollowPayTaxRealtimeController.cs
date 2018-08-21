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
    public class FollowPayTaxRealtimeController : ApiController
    {
        TaxRealtime tax = new TaxRealtime();
        // GET: api/FollowPayTaxRealtime
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FollowPayTaxRealtime/5
        public IHttpActionResult Get(string month,string year)
        {
            var jsonString = JsonConvert.SerializeObject(tax.FollowPayTaxRealtime(month, year));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/FollowPayTaxRealtime
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FollowPayTaxRealtime/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FollowPayTaxRealtime/5
        public void Delete(int id)
        {
        }
    }
}
