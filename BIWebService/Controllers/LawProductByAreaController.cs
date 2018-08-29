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
    public class LawProductByAreaController : ApiController
    {
        LawReport tax = new LawReport();
        // GET: api/LawProductByArea
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LawProductByArea/5
        public IHttpActionResult Get(string offcode, string region, string province, string group_desc)
        {
            var jsonString = JsonConvert.SerializeObject(tax.LawProductByArea(offcode, region, province, group_desc));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/LawProductByArea
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LawProductByArea/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LawProductByArea/5
        public void Delete(int id)
        {
        }
    }
}
