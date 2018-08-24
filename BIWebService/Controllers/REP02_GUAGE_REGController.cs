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
    public class REP02_GUAGE_REGController : ApiController
    {
        REP02_GUAGE_REG tax = new REP02_GUAGE_REG();
        // GET: api/REP02_GUAGE_REG
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/REP02_GUAGE_REG/5
        public IHttpActionResult Get(string area)
        {
            var jsonString = JsonConvert.SerializeObject(tax.GUAGE_REG(area));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/REP02_GUAGE_REG
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/REP02_GUAGE_REG/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/REP02_GUAGE_REG/5
        public void Delete(int id)
        {
        }
    }
}
