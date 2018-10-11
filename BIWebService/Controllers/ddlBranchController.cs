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
    public class ddlBranchController : ApiController
    {
        DDLMaster sql = new DDLMaster();
        public IHttpActionResult get(string area, string province)
        {
            var jsonString = JsonConvert.SerializeObject(sql.ddlBranch(area, province));
            return new RawJsonActionResult(jsonString);
        }
    }
}
