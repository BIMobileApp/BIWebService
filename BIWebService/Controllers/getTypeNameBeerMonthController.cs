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
    public class getTypeNameBeerMonthController : ApiController
    {
        CompareTax tax = new CompareTax();
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.getTypeNameBeerMonth(offcode));
            return new RawJsonActionResult(jsonString);
        }
    }
}
