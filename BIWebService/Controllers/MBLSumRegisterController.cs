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
    public class MBLSumRegisterController : ApiController
    {
        MBLRegister tax = new MBLRegister();

        public IHttpActionResult Get(string offcode, string region, string province, string type)
        {
            var jsonString = JsonConvert.SerializeObject(tax.SumRegister(offcode, region, province, type));
            return new RawJsonActionResult(jsonString);
        }
    }
}
