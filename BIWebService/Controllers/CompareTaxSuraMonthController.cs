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
    public class CompareTaxSuraMonthController : ApiController
    {
        CompareTax tax = new CompareTax();
        
        public IHttpActionResult Get(string code, string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.CompareTaxSuraMonth(code, offcode));
            return new RawJsonActionResult(jsonString);
        }
    }
}
