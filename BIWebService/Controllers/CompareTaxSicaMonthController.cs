﻿using BILibraryBLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BIWebService.Controllers
{
    public class CompareTaxSicaMonthController : ApiController
    {
        CompareTax tax = new CompareTax();

        public IHttpActionResult Get(string TYPE_DESC, string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.CompareTaxSicaMonth(TYPE_DESC, offcode));
            return new RawJsonActionResult(jsonString);
        }

        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.CompareTaxSicaMonthAll(offcode));
            return new RawJsonActionResult(jsonString);
        }
    }
}
