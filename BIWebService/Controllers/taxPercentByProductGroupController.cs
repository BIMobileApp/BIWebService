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
    public class taxPercentByProductGroupController : ApiController
    {
        GaugeAllmthSectionSQL tax = new GaugeAllmthSectionSQL();
        // GET: api/taxPercentByProductGroup
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/taxPercentByProductGroup/5
        public IHttpActionResult Get(string year, string grp_id)
        {
            var jsonString = JsonConvert.SerializeObject(tax.taxPercentByProductGroup(year, grp_id));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/taxPercentByProductGroup
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/taxPercentByProductGroup/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/taxPercentByProductGroup/5
        public void Delete(int id)
        {
        }
    }
}
