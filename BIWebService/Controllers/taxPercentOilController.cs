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
    public class taxPercentOilController : ApiController
    {
        GaugeProduct tax = new GaugeProduct();

        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxPercentOil(offcode));
            return new RawJsonActionResult(jsonString);
        }
    }
}
