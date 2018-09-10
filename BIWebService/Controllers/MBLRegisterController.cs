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
    public class MBLRegisterController : ApiController
    {
        MBLRegister tax = new MBLRegister();
        // GET: api/MBLRegister
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MBLRegister/5
        public IHttpActionResult Get(string offcode,string region,string province)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxRegisterByOffcode(offcode, region, province));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/MBLRegister
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MBLRegister/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MBLRegister/5
        public void Delete(int id)
        {
        }
    }
}
