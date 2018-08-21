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
    public class TaxBudgetRegByMthController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();
        // GET: api/TaxBudgetRegByMth
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxBudgetRegByMthAll());
            return new RawJsonActionResult(jsonString);
        }

        // GET: api/TaxBudgetRegByMth/5
        public IHttpActionResult Get(string mth)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxBudgetRegByMth(mth));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/TaxBudgetRegByMth
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TaxBudgetRegByMth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaxBudgetRegByMth/5
        public void Delete(int id)
        {
        }
    }
}
