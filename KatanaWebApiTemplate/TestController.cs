using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace KatanaWebApiTemplate
{
    public class TestController : ApiController
    {
        // put web api methods here....
        public async Task<HttpResponseMessage> Get(string id)
        {
            return await Task.FromResult(Request.CreateResponse<string>(HttpStatusCode.OK, "Hello world!"));
        }
    }
}
