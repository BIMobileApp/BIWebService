using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BIWebService.Controllers
{
    public class SelectRealtimeRegionController : ApiController
    {
        // GET: api/SelectRealtimeRegion
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SelectRealtimeRegion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SelectRealtimeRegion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SelectRealtimeRegion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SelectRealtimeRegion/5
        public void Delete(int id)
        {
        }
    }
}
