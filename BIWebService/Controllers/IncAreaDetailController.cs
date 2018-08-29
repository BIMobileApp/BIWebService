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
    public class IncAreaDetailController : ApiController
    {
        IncData tax = new IncData();

        // GET: api/IncAreaDetail
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/IncAreaDetail/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.IncDataByAreaDetail(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/IncAreaDetail
        public void Post([FromBody]string value)
        {
        } 

        // PUT: api/IncAreaDetail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/IncAreaDetail/5
        public void Delete(int id)
        {
        }
    }
}
