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
    public class CompareTaxCarController : ApiController
    {
        CompareTax tax = new CompareTax();

        public IHttpActionResult Get(string area, string Province, string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.CompareTaxCar(area, Province, offcode));
            return new RawJsonActionResult(jsonString);
        }
    }
}
