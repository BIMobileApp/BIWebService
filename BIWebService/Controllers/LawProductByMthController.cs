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
    public class LawProductByMthController : ApiController
    {
        LawReport tax = new LawReport();
        // GET: api/LawProductByMth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LawProductByMth/5
        public IHttpActionResult Get(string offcode, string region, string province, string group_desc, string mth)
        {
            var jsonString = JsonConvert.SerializeObject(tax.LawProductByMth(offcode, region, province, group_desc, mth));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/LawProductByMth
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LawProductByMth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LawProductByMth/5
        public void Delete(int id)
        {
        }
    }
}
