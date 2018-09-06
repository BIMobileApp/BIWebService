using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BILibraryBLL;
using Newtonsoft.Json;

namespace BIWebService.Controllers
{
    public class SourceImcomeController : ApiController
    {
        SourceImcome income = new SourceImcome();

        // GET: api/SourceImcome/5
        public IHttpActionResult Get(string offcode,string region,string province)
        {
            var jsonString = JsonConvert.SerializeObject(income.IncomeList(offcode, region, province));
            return new RawJsonActionResult(jsonString);
        }        
    }
}
