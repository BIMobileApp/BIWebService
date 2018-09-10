using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BILibraryBLL;

namespace BIWebService.Controllers
{
    public class selectionTaxDailyRegionController : ApiController
    {
        TaxDaily tax = new TaxDaily();
        // GET: api/SelectionProvince/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.MRegion(offcode));
            return new RawJsonActionResult(jsonString);
        }
    }
}
