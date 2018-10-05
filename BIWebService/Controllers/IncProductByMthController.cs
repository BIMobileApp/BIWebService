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
    public class IncProductByMthController : ApiController
    {
        IncData tax = new IncData();
        // GET: api/IncProductByMth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/IncProductByMth/5
        public IHttpActionResult Get(string offcode, string region, string province, string month_from, string month_to, string group_name)
        {
            var jsonString = JsonConvert.SerializeObject(tax.IncProductByMth(offcode, region, province, month_from, month_to, group_name));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/IncProductByMth
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/IncProductByMth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/IncProductByMth/5
        public void Delete(int id)
        {
        }
    }
}
