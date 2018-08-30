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
    public class SelectionLawProvinceController : ApiController
    {
        LawMasterData tax = new LawMasterData();

        // GET: api/SelectionLawProvince
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SelectionLawProvince/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.SelectionLawProvince(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/SelectionLawProvince
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SelectionLawProvince/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SelectionLawProvince/5
        public void Delete(int id)
        {
        }
    }
}
