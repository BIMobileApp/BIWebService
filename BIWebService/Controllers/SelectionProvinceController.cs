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
    public class SelectionProvinceController : ApiController
    {
        IncMasterData tax = new IncMasterData();
        // GET: api/SelectionProvince
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SelectionProvince/5
        public IHttpActionResult Get(string offcode,string area)
        {
            var jsonString = JsonConvert.SerializeObject(tax.SelectionProvince(offcode,area));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/SelectionProvince
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SelectionProvince/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SelectionProvince/5
        public void Delete(int id)
        {
        }
    }
}
