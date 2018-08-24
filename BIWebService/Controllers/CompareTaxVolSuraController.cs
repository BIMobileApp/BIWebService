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
    public class CompareTaxVolSuraController : ApiController
    {
<<<<<<< HEAD
<<<<<<< HEAD:BIWebService/Controllers/CompareTaxLineGraphController.cs
        CompareTax dt = new CompareTax();
        public IHttpActionResult Get(string group_name, string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(dt.CompareTaxLineGraph(group_name, offcode));
=======
=======
>>>>>>> f49c7a8104e275b0f5e84eecba421104f4c4cc92
        CompareTax tax = new CompareTax();
        
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(tax.CompareTaxVolSura(offcode));
<<<<<<< HEAD
>>>>>>> eabd1e2411e0fe5f3f31f988a6c6b2ed46d7c9ba:BIWebService/Controllers/CompareTaxVolSuraController.cs
=======
>>>>>>> f49c7a8104e275b0f5e84eecba421104f4c4cc92
            return new RawJsonActionResult(jsonString);
        }
    }
}
