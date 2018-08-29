using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BILibraryBLL;
using Newtonsoft.Json;

namespace BIWebService.Controllers
{
    public class SelectionLawAreaController : ApiController
    {
        LawMasterData tax = new LawMasterData();

        // GET: api/SelectionLawArea
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SelectionLawArea/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.SelectionLawArea(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/SelectionLawArea
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SelectionLawArea/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SelectionLawArea/5
        public void Delete(int id)
        {
        }
    }
}
