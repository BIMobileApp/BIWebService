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
    public class SelectionLawMthGroupNameController : ApiController
    {
        LawMasterData tax = new LawMasterData();
        // GET: api/SelectionLawMthGroupName
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SelectionLawMthGroupName/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.SelectionLawMthGroupName(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/SelectionLawMthGroupName
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SelectionLawMthGroupName/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SelectionLawMthGroupName/5
        public void Delete(int id)
        {
        }
    }
}
