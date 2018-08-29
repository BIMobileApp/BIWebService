using BILibraryBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BIWebService.Controllers
{
    public class MasterProvinceController : ApiController
    {
        MasterData tax = new MasterData();

        // GET: api/MasterProvince
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /*public IHttpActionResult Get(string offcode)
       {
           var jsonString = JsonConvert.SerializeObject(tax.ProvinceList(offcode));
           return new RawJsonActionResult(jsonString);
       }*/


        // GET: api/MasterProvince/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MasterProvince
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MasterProvince/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MasterProvince/5
        public void Delete(int id)
        {
        }
    }
}
