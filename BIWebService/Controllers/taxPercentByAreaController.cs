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
    public class taxPercentByAreaController : ApiController
    {
        GaugeAllmthSectionSQL tax = new GaugeAllmthSectionSQL();
        // GET: api/taxPercentByArea
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/taxPercentByArea/5
        public IHttpActionResult Get(string area)
        {
            var jsonString = JsonConvert.SerializeObject(tax.taxPercentArea(area));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/taxPercentByArea
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/taxPercentByArea/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/taxPercentByArea/5
        public void Delete(int id)
        {
        }
    }
}
