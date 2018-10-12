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
    public class TaxCurProductOfBranchController : ApiController
    {
        TaxBranch tax = new TaxBranch();

        public IHttpActionResult Get(string offcode, string area, string province)
        {
            var jsonString = JsonConvert.SerializeObject(tax.TaxCurProduct(offcode, area, province));
            return new RawJsonActionResult(jsonString);
        }
    }
}