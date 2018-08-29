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
    public class SelectionMthGroupNameController : ApiController
    {
        IncMasterData tax = new IncMasterData();
        // GET: api/SelectionMthGroupName
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SelectionMthGroupName/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.SelectionMthGroupName(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/SelectionMthGroupName
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SelectionMthGroupName/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SelectionMthGroupName/5
        public void Delete(int id)
        {
        }
    }
}
