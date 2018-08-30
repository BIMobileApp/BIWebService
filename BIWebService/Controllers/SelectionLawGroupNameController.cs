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
    public class SelectionLawGroupNameController : ApiController
    {
        LawMasterData tax = new LawMasterData();
        // GET: api/SelectionLawGroupName
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SelectionLawGroupName/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.SelectionLawGroupName(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/SelectionLawGroupName
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SelectionLawGroupName/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SelectionLawGroupName/5
        public void Delete(int id)
        {
        }
    }
}
