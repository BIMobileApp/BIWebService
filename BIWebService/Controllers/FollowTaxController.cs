using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BILibraryBLL;
using ClassLib;

namespace BIWebService.Controllers
{
    public class FollowTaxController : ApiController
    {
        FollowTax fow = new FollowTax();
        // GET: api/FollowTax
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(fow.FollowTaxMth());
            return new RawJsonActionResult(jsonString);
        }

        // GET: api/FollowTax/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FollowTax
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FollowTax/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FollowTax/5
        public void Delete(int id)
        {
        }
    }
}
