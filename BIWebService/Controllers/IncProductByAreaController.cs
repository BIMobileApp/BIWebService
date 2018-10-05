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
    public class IncProductByAreaController : ApiController
    {
        IncData tax = new IncData();
        // GET: api/IncProductByArea
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/IncProductByArea/5
        public IHttpActionResult Get(string offcode, string region, string province, string group_desc, string month_from,string month_to)
        {
            var jsonString = JsonConvert.SerializeObject(tax.IncProductByArea(offcode, region, province, group_desc, month_from, month_to));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/IncProductByArea
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/IncProductByArea/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/IncProductByArea/5
        public void Delete(int id)
        {
        }
    }
}
