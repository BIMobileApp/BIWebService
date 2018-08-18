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
    public class taxQuantityByProductGroupController : ApiController
    {
        GaugeAllmthSectionSQL tax = new GaugeAllmthSectionSQL();
        // GET: api/taxQuantityByProductGroup
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/taxQuantityByProductGroup/5
        public IHttpActionResult Get(string year, string grp_id)
        {
            var jsonString = JsonConvert.SerializeObject(tax.taxPercentQuantity(year, grp_id));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/taxQuantityByProductGroup
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/taxQuantityByProductGroup/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/taxQuantityByProductGroup/5
        public void Delete(int id)
        {
        }
    }
}
