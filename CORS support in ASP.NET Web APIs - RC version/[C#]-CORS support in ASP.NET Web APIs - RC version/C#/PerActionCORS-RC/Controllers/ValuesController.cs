using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using PerActionCORS_RC.ActionSelectors;
using PerActionCORS_RC.Filters;

namespace PerActionCORS_RC.Controllers
{
    [HttpControllerConfiguration(HttpActionSelector = typeof(CorsPreflightActionSelector))]
    public class ValuesController : ApiController
    {
        static List<string> allValues = new List<string> { "value1", "value2" };

        // GET /api/values
        [EnableCors]
        public IEnumerable<string> Get()
        {
            return allValues;
        }

        // GET /api/values/5
        [EnableCors]
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
        [EnableCors]
        public HttpResponseMessage Post([FromBody]string value)
        {
            allValues.Add(value);
            return this.Request.CreateResponse<int>(HttpStatusCode.Created, allValues.Count - 1);
        }

        // PUT /api/values/5
        [EnableCors]
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
