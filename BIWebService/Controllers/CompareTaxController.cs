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
    public class CompareTaxController : ApiController
    {
        CompareTax tax = new CompareTax();
        // GET: api/CompareTax
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CompareTax/5
        public IHttpActionResult Get(string grp_name)
        {
            var jsonString = JsonConvert.SerializeObject(tax.CompareTaxByGroup(grp_name));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/CompareTax
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CompareTax/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CompareTax/5
        public void Delete(int id)
        {
        }
    }
}
