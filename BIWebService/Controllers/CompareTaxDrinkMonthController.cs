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
    public class CompareTaxDrinkMonthController : ApiController
    {
        CompareTax tax = new CompareTax();

        public IHttpActionResult Get()
        {
            var jsonString = JsonConvert.SerializeObject(tax.getTypeNameDrinkMonth());
            return new RawJsonActionResult(jsonString);
        }
        public IHttpActionResult Get(string code, string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.CompareTaxDrinkMonth(code, offcode));
            return new RawJsonActionResult(jsonString);
        }
    }
}
