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
    public class SelectionAreaController : ApiController
    {
        IncMasterData tax = new IncMasterData();
        // GET: api/SelectionArea
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SelectionArea/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.SelectionArea(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/SelectionArea
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SelectionArea/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SelectionArea/5
        public void Delete(int id)
        {
        }
    }
}
