using BILibraryBLL;
using ClassLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BIWebService.Controllers
{
    public class OldBarAllTaxController : ApiController
    {
        ConnectionStringTest con = new ConnectionStringTest();
        OldBarAllTaxSQL dt = new OldBarAllTaxSQL();

        //Get Api
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(dt.SQL1());
            return new RawJsonActionResult(jsonString);
        }
    }
}
