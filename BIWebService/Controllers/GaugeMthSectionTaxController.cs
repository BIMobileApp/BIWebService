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
    public class GaugeMthSectionTaxController : ApiController
    {
        Conn con = new Conn();
        GaugeAllmthSectionSQL dt = new GaugeAllmthSectionSQL();

        //Get Api
        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(dt.SQL1());
            return new RawJsonActionResult(jsonString);
        }

    }
}
