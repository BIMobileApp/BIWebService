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
    public class IncSumDataByMonthController : ApiController
    {
        IncData tax = new IncData();
        // GET: api/IncSumDataByMonth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/IncSumDataByMonth/5
        public IHttpActionResult Get(string offcode,string province, string region)
        {
            var jsonString = JsonConvert.SerializeObject(tax.IncSumDataByMonth(offcode, province, region));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/IncSumDataByMonth
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/IncSumDataByMonth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/IncSumDataByMonth/5
        public void Delete(int id)
        {
        }
    }
}
