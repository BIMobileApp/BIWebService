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
    public class CompareTaxDrinkController : ApiController
    {
        CompareTax tax = new CompareTax();

        public IHttpActionResult Get(string area, string Province, string offcode)
        {
<<<<<<< HEAD
            var jsonString = JsonConvert.SerializeObject(tax.CompareTaxDrink(area, Province, offcode));
=======
            var jsonString = JsonConvert.SerializeObject(tax.CompareTaxDrink(area, Province, Province));
>>>>>>> 6676944a65b11ed598ef08a2bf5bb7b54e2d96a0
            return new RawJsonActionResult(jsonString);
        }
    }
}
