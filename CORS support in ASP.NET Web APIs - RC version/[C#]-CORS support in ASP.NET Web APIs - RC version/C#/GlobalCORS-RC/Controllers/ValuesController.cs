using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GlobalCORS_RC.Controllers
{
    public class ValuesController : ApiController
    {
        static List<string> allValues = new List<string> { "value1", "value2" };

        // GET /api/values
        public IEnumerable<string> Get()
        {
            return allValues;
        }

        // GET /api/values/5
        public string Get(int id)
        {
            if (id < allValues.Count)
            {
                return allValues[id];
            }
            else
            {
                throw new HttpResponseException(this.Request.CreateResponse(HttpStatusCode.NotFound));
            }
        }

        // POST /api/values
        public HttpResponseMessage Post([FromBody]string value)
        {
            allValues.Add(value);
            return this.Request.CreateResponse<int>(HttpStatusCode.Created, allValues.Count - 1);
        }

        // PUT /api/values/5
        public void Put(int id, [FromBody] string value)
        {
            if (id < allValues.Count)
            {
                allValues[id] = value;
            }
            else
            {
                throw new HttpResponseException(this.Request.CreateResponse(HttpStatusCode.NotFound));
            }
        }

        // DELETE /api/values/5
        public void Delete(int id)
        {
            if (id < allValues.Count)
            {
                allValues.RemoveAt(id);
            }
            else
            {
                throw new HttpResponseException(this.Request.CreateResponse(HttpStatusCode.NotFound));
            }
        }
    }
}