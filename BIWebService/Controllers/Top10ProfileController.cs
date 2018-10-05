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
    public class Top10ProfileController : ApiController
    {
        TaxBudgetYear tax = new TaxBudgetYear();

        // GET: api/TaxBudgetRegAll/5

        public IHttpActionResult Get(string offcode, string group_id, string region, string province, string month_from, string month_to)
        {
            var jsonString = JsonConvert.SerializeObject(tax.Top10Profile(offcode, group_id, region, province, month_from, month_to));
            return new RawJsonActionResult(jsonString);
        }
    }
}