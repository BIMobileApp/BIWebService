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
    public class SourceImcomeController : ApiController
    {
        SourceImcome income = new SourceImcome();
        // GET: api/SourceImcome
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(income.ImcomeList());
            return new RawJsonActionResult(jsonString);
        }

        // GET: api/SourceImcome/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SourceImcome
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SourceImcome/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SourceImcome/5
        public void Delete(int id)
        {
        }
    }
}
