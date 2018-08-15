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
    public class TMP_USERController : ApiController
    {
        TMP_USER dt = new TMP_USER();
        public IHttpActionResult Get(string username, string password)
        {
            var jsonString = JsonConvert.SerializeObject(dt.getUSER(username,password));
            return new RawJsonActionResult(jsonString);
        }
    }
}
