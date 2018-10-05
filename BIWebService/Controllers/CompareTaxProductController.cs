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
    public class CompareTaxProductController : ApiController
    {

        CompareTax tax = new CompareTax();

        public IHttpActionResult Get(string area, string Province, string offcode, string month_from, string month_to, string dbtable)
        {
            
            var jsonString = JsonConvert.SerializeObject(tax.CompareTaxProduct(area, Province, offcode, month_from, month_to, dbtable));
            return new RawJsonActionResult(jsonString);
        }
    }
}
