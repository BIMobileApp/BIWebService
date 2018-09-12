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
    public class TopRegSegmentController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();
        public IHttpActionResult Get(string offcode, string group_id, string area, string province)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxTopRegSegment(offcode, group_id, area, province));
            return new RawJsonActionResult(jsonString);
        }
    }
}
