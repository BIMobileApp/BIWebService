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
    public class ddlMBranchController : ApiController
    {
        DDLMaster sql = new DDLMaster();
        public IHttpActionResult get(string offcode, string area)
        {
            var jsonString = JsonConvert.SerializeObject(sql.MBrach(offcode, area)); 
            return new RawJsonActionResult(jsonString);
        }
    }
}
