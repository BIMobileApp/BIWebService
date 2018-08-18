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
    public class TaxCurYearController : ApiController
    {
       
        TaxBudgetYear tax = new TaxBudgetYear();
        
        // GET: api/TaxBudgetYear/
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxCurYear());
            return new RawJsonActionResult(jsonString);
        }

    }
}
