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
    public class LawProductByMthAllController : ApiController
    {
        LawReport tax = new LawReport();
        // GET: api/LawProductByMthAll
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LawProductByMthAll/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.LawProductByMthAll(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/LawProductByMthAll
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LawProductByMthAll/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LawProductByMthAll/5
        public void Delete(int id)
        {
        }
    }
}
