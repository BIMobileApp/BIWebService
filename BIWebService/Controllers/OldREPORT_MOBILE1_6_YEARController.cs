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
    public class OldREPORT_MOBILE1_6_YEARController : ApiController
    {
        OldReportSQL sql = new OldReportSQL();
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(sql.REPORT_MOBILE1_6_YEAR());
            return new RawJsonActionResult(jsonString);
        }
    }
}
