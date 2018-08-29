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
    public class SelectionGroupNameController : ApiController
    {
        MasterData tax = new MasterData();
        // GET: api/SelectionGroupName
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SelectionGroupName/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.SelectionGroupName(offcode));
            return new RawJsonActionResult(jsonString);
        }
        // POST: api/SelectionGroupName
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SelectionGroupName/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SelectionGroupName/5
        public void Delete(int id)
        {
        }
    }
}
