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
    public class SelectionMthProvinceController : ApiController
    {
        IncMasterData tax = new IncMasterData();

        // GET: api/SelectionMthProvince
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SelectionMthProvince/5
        public IHttpActionResult Get(string offcode,string region)
        {
            var jsonString = JsonConvert.SerializeObject(tax.SelectionMthProvince(offcode, region));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/SelectionMthProvince
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SelectionMthProvince/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SelectionMthProvince/5
        public void Delete(int id)
        {
        }
    }
}
