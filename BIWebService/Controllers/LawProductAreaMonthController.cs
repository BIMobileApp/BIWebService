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
    public class LawProductAreaMonthController : ApiController
    {
        LawReport tax = new LawReport();
        // GET: api/LawProductByMthAll/5
        public IHttpActionResult Get(string offcode, string region, string province, string month_from, string month_to)
        {
            var jsonString = JsonConvert.SerializeObject(tax.LawProductAreaMonth(offcode, region, province, month_from, month_to));
            return new RawJsonActionResult(jsonString);
        }
    }
}
