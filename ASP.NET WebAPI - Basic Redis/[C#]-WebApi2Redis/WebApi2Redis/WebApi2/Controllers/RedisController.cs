using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi2.Controllers
{
    public class RedisController : ApiController
    {
        // GET: api/Redis/key
        public string Get(string key)
        {
            using (var redis = new RedisClient("localhost", 6379))
            {
                return redis.GetEntry(key);
            }  
        }

        // POST: api/Redis
        public void Post(string key, string keyValue)
        {
            using (var redis = new RedisClient("localhost", 6379))
            {
                redis.SetEntry(key, keyValue);
            }
        }        
    }
}
