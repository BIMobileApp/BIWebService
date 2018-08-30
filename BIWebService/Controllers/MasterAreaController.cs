using BILibraryBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BIWebService.Controllers
{
    public class MasterAreaController : ApiController
    {
        IncMasterData tax = new IncMasterData();

        // GET: api/MasterArea
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /*public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.AreaList(offcode));
            return new RawJsonActionResult(jsonString);
        }*/

        // GET: api/MasterArea/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MasterArea
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MasterArea/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MasterArea/5
        public void Delete(int id)
        {
        }
    }
}
