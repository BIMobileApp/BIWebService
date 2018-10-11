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
    public class DateTitleController : ApiController
    {
        DataStatus data = new DataStatus();
        public IHttpActionResult get(string startMonth, string endMonth)
        {
            var jsonString = JsonConvert.SerializeObject(data.DateTitle(startMonth, endMonth));
            return new RawJsonActionResult(jsonString);
        }
    }
}
