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
    public class IncAreaController : ApiController
    {
        IncData tax = new IncData();
        // GET: api/LowArea
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LowArea/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.IncDataByArea(offcode));
            return new RawJsonActionResult(jsonString);
        }
    

        // POST: api/LowArea
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LowArea/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LowArea/5
        public void Delete(int id)
        {
        }
    }
}
