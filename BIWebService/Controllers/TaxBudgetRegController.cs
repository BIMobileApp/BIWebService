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
        
        // GET: api/TaxBudgetReg/5
        public IHttpActionResult Get(string offcode, string group_id, string year)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxBudgetReg(offcode, group_id, year));
            return new RawJsonActionResult(jsonString);
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
