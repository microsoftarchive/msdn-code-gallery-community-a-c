using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleWebApiSelfHost
{
    public class UserController : ApiController
    {
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        public string[] Get()
        {
            return new[] { "user1", "user2" };
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return true;
        }
    }
}