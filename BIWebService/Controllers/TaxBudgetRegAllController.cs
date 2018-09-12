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
    public class TaxBudgetRegAllController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();

        // GET: api/TaxBudgetRegAll/5

        public IHttpActionResult Get(string offcode,string group_id,string region, string province,string year)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxBudgetRegAll(offcode, group_id, region, province, year));
            return new RawJsonActionResult(jsonString);
        }

    }
}
