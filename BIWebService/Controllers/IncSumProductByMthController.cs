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
    public class IncSumProductByMthController : ApiController
    {
        IncData tax = new IncData();

        // GET: api/IncSumProductByMth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/IncSumProductByMth/5
        // GET: api/IncProductByMth/5
        public IHttpActionResult Get(string offcode, string region, string province, string type_name, string group_name)
        {
            var jsonString = JsonConvert.SerializeObject(tax.IncSumProductByMth(offcode, region, province, type_name, group_name));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/IncSumProductByMth
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/IncSumProductByMth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/IncSumProductByMth/5
        public void Delete(int id)
        {
        }
    }
}
