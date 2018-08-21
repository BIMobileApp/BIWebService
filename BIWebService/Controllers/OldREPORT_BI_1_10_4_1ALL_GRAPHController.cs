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
    public class OldREPORT_BI_1_10_4_1ALL_GRAPHController : ApiController
    {
        OldReportSQL sql = new OldReportSQL();
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(sql.REPORT_BI_1_10_4_1ALL_GRAPH());
            return new RawJsonActionResult(jsonString);
        }
    }
}
