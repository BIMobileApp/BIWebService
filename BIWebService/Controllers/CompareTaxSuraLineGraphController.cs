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
    public class CompareTaxSuraLineGraphController : ApiController
    {
        CompareTax tax = new CompareTax();

        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(tax.getTypeNameSuraMonth());
            return new RawJsonActionResult(jsonString);
        }
        public IHttpActionResult Get(string code)
        {
            var jsonString = JsonConvert.SerializeObject(tax.CompareTaxSuraMonth(code));
            return new RawJsonActionResult(jsonString);
        }
    }
}
