using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BILibraryBLL;
using Newtonsoft.Json;

namespace BIWebService.Controllers
{
    public class LawProductAreaAllController : ApiController
    {
        LawReport tax = new LawReport();
        // GET: api/LawProductAreaAll
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LawProductAreaAll/5
        public IHttpActionResult Get(string offcode,string group_name)
        {
            var jsonString = JsonConvert.SerializeObject(tax.LawProductAreaAll(offcode, group_name));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/LawProductAreaAll
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LawProductAreaAll/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LawProductAreaAll/5
        public void Delete(int id)
        {
        }
    }
}
