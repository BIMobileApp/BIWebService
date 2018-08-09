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
    
    public class getProductController : ApiController
    {
        newReportLineFollowProdSQL dt = new newReportLineFollowProdSQL();
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(dt.getProduct());
            return new RawJsonActionResult(jsonString);
        }
    }
}
