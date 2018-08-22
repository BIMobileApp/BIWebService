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
    public class SumTaxBudgetRegController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();
        // GET: api/SumTaxBudgetReg
        public string Get()
        {
            var jsonString = tax.SumTaxBudgetRegAll();//JsonConvert.SerializeObject(tax.SumTaxBudgetReg());
            return jsonString;
        }

        // GET: api/SumTaxBudgetReg/5
        public string Get(string year)
        {
            var jsonString = tax.SumTaxBudgetReg(year);//JsonConvert.SerializeObject(tax.SumTaxBudgetReg());
            return jsonString;
        }

        // POST: api/SumTaxBudgetReg
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SumTaxBudgetReg/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SumTaxBudgetReg/5
        public void Delete(int id)
        {
        }
    }
}
