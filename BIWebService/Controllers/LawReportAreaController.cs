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
    public class LawReportAreaController : ApiController
    {
        LawReport tax = new LawReport();
        public IHttpActionResult Get(string offcode, string region, string province, string group_desc)
        {
            var jsonString = JsonConvert.SerializeObject(tax.LawReportArea(offcode, region, province, group_desc));
            return new RawJsonActionResult(jsonString);
        }
    }
}
