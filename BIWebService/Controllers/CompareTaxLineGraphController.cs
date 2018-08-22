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
    
    public class CompareTaxLineGraphController : ApiController
    {
        CompareTax dt = new CompareTax();
        public IHttpActionResult Get(string group_name, string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(dt.CompareTaxLineGraph(group_name, offcode));
            return new RawJsonActionResult(jsonString);
        }
        
    }
}
