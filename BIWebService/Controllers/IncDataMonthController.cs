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
    public class IncDataMonthController : ApiController
    {
        IncData tax = new IncData();
        // GET: api/LawDataMonth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LawDataMonth/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.IncDataByMonth(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/LawDataMonth
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LawDataMonth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LawDataMonth/5
        public void Delete(int id)
        {
        }
    }
}
