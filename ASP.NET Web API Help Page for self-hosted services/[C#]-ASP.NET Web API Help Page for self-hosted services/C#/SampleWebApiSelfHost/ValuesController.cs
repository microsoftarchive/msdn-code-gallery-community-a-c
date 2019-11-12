using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleWebApiSelfHost
{
    public class ValuesController : ApiController
    {
        // GET api/values
        /// <summary>
        /// Gets values.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        /// <summary>
        /// Gets the value specified by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        /// <summary>
        /// Creates a new value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        /// <summary>
        /// Updates a value.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="value">The value.</param>
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        /// <summary>
        /// Deletes the value.
        /// </summary>
        /// <param name="id">The id.</param>
        public void Delete(int id)
        {
        }
    }
}