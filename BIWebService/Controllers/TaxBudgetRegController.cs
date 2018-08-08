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
    public class TaxBudgetRegController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();
        // GET: api/TaxBudgetReg
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxBudgetReg());
            return new RawJsonActionResult(jsonString);
        }

        // GET: api/TaxBudgetReg/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TaxBudgetReg
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TaxBudgetReg/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaxBudgetReg/5
        public void Delete(int id)
        {
        }
    }
}
