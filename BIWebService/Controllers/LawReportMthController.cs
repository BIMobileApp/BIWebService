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
    public class LawReportMthController : ApiController
    {
        LawReport tax = new LawReport();
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.LawReportMth(offcode));
            return new RawJsonActionResult(jsonString);
        }
    }
}
