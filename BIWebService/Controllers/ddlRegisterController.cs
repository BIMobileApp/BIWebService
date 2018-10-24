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
    

    public class ddlRegisterController : ApiController
    {
        MBLRegister tax = new MBLRegister();

        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(tax.ddlRegister());
            return new RawJsonActionResult(jsonString);
        }
    }
}
