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
    public class AuthenticateUserController : ApiController
    {
        TMP_USER tax = new TMP_USER();

        public string Get(string username, string password)
        {
            var reponseData = tax.AuthenticateUser(username, password);
            return reponseData;
        }
    }
}
