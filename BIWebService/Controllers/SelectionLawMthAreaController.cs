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
    public class SelectionLawMthAreaController : ApiController
    {
        LawMasterData tax = new LawMasterData();

        // GET: api/SelectionLawMthArea
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SelectionLawMthArea/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.SelectionLawMthArea(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/SelectionLawMthArea
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SelectionLawMthArea/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SelectionLawMthArea/5
        public void Delete(int id)
        {
        }
    }
}
