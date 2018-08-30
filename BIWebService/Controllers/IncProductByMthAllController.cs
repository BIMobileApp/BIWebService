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
    public class IncProductByMthAllController : ApiController
    {
        IncData tax = new IncData();
        // GET: api/IncProductByMthAll
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/IncProductByAreaAll/5
        public IHttpActionResult Get(string offcode, string group_name)
        {
            var jsonString = JsonConvert.SerializeObject(tax.IncProductByMthAll(offcode, group_name));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/IncProductByMthAll
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/IncProductByMthAll/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/IncProductByMthAll/5
        public void Delete(int id)
        {
        }
    }
}
