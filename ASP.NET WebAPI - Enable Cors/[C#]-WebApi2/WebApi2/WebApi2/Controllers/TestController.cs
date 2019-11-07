using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi2.Controllers
{
    [EnableCors(origins: "http://localhost:53029", headers: "*", methods: "*")]
    public class TestController : ApiController
    {
        public string Get()
        {
            return "This is my controller response";
        }
    }
}
