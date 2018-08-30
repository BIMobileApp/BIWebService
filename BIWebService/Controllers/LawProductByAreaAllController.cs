﻿using BILibraryBLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BIWebService.Controllers
{
    public class LawProductByAreaAllController : ApiController
    {
        LawReport tax = new LawReport();
        // GET: api/LawProductByAreaAll
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LawProductByAreaAll/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.LawProductAreaAll(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/LawProductByAreaAll
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LawProductByAreaAll/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LawProductByAreaAll/5
        public void Delete(int id)
        {
        }
    }
}
