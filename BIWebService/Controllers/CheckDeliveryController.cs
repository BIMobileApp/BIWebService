using BILibraryBLL;
using Newtonsoft.Json;
using System.Web.Http;

namespace BIWebService.Controllers
{
    public class CheckDeliveryController : ApiController
    {
        CheckDelivery deli = new CheckDelivery();
        // GET: api/CheckDelivery
        public string Get()
        {
            //var jsonString = JsonConvert.SerializeObject(deli.CheckDeliveryAllTaxPage());
            return "";//new RawJsonActionResult(jsonString);
        }

        // GET: api/CheckDelivery/5
        public IHttpActionResult Get(string st_date, string en_date)
        {
            var jsonString = JsonConvert.SerializeObject(deli.CheckDeliveryAllTaxPage(st_date,en_date));
            return new RawJsonActionResult(jsonString);
        }

        // POST: api/CheckDelivery
        public void Post()
        {

        }

        // PUT: api/CheckDelivery/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CheckDelivery/5
        public void Delete(int id)
        {
        }
    }
}
