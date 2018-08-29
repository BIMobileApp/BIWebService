using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BILibraryBLL;

namespace BIWebService.Controllers
{
    public class MasterBranchController : ApiController
    {
        MasterData tax = new MasterData();
        // GET: api/MasterBranch
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /*public IHttpActionResult Get(string offcode)
          {
            var jsonString = JsonConvert.SerializeObject(tax.BranchList(offcode));
            return new RawJsonActionResult(jsonString);
          }*/

        // GET: api/MasterBranch/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MasterBranch
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MasterBranch/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MasterBranch/5
        public void Delete(int id)
        {
        }
    }
}
