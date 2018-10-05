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
    public class getDatadateController : ApiController
    {
        TMP_USER date = new TMP_USER();

        //public IHttpActionResult Get(string menu_cd)
        //{
        //    var jsonString = JsonConvert.SerializeObject(date.getData_date(menu_cd));
        //    return new RawJsonActionResult(jsonString);
        //}
    }
}
