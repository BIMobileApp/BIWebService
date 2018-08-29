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
    public class SumIncomeListController : ApiController
    {
        SourceImcome income = new SourceImcome();
        // GET: api/SumIncomeList
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SumIncomeList/5
        public IHttpActionResult Get(string offcode)
        {
            var jsonString = JsonConvert.SerializeObject(income.SumIncomeList(offcode));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/SumIncomeListq
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SumIncomeList/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SumIncomeList/5
        public void Delete(int id)
        {
        }
    }
}
