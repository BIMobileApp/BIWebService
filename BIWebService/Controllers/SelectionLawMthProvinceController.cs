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
    public class SelectionLawMthProvinceController : ApiController
    {
        LawMasterData tax = new LawMasterData();
        // GET: api/SelectionLawMthProvince
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SelectionLawMthProvince/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.SelectionLawMthProvince(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/SelectionLawMthProvince
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SelectionLawMthProvince/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SelectionLawMthProvince/5
        public void Delete(int id)
        {
        }
    }
}
