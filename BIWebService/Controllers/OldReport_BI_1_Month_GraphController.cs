﻿using BILibraryBLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BIWebService.Controllers
{
    public class OldReport_BI_1_Month_GraphController : ApiController
    {
        OldReportSQL sql = new OldReportSQL();
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(sql.REPORT_BI_1_MONTH_GRAPH());
            return new RawJsonActionResult(jsonString);
        }
    }
}
