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
    public class CompareTaxSuraController : ApiController
    {
        CompareTax tax = new CompareTax();
  
        public IHttpActionResult Get(string area, string Province, string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.CompareTaxSura(area, Province, offcode));
            return new RawJsonActionResult(jsonString);
        }

    }
}
