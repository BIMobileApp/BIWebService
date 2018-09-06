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
    public class selectionTaxDailyProvinceController : ApiController
    {
        TaxDaily tax = new TaxDaily();

        public IHttpActionResult Get(string offcode,string area)
        {
            var jsonString = JsonConvert.SerializeObject(tax.MProvince(offcode, area));
            return new RawJsonActionResult(jsonString);
        }
    }
}
