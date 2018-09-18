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
    public class DimansionTime03Controller : ApiController
    {
        DimansionTime tax = new DimansionTime();

        public IHttpActionResult Get(string offcode, string region, string province,string month)
        {
            var jsonString = JsonConvert.SerializeObject(tax.DimansionTime03(offcode, region, province, month));
            return new RawJsonActionResult(jsonString);
        }
    }
}
