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
    public class SelectionMthAreaController : ApiController
    {
        IncMasterData tax = new IncMasterData();
        // GET: api/SelectionMthArea
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SelectionMthArea/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.SelectionMthArea(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/SelectionMthArea
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SelectionMthArea/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SelectionMthArea/5
        public void Delete(int id)
        {
        }
    }
}
