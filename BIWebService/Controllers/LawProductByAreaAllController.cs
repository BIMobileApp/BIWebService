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
    public class LawProductByAreaAllController : ApiController
    {
        LawReport tax = new LawReport();

        public IHttpActionResult Get(string offcode,string group_name)
        {
            var jsonString = JsonConvert.SerializeObject(tax.LawProductAreaAll(offcode, group_name));
            return new RawJsonActionResult(jsonString);
        }

    }
}
