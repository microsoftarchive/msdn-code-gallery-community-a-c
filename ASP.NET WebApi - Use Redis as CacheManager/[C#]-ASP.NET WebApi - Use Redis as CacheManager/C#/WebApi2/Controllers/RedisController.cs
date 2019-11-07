using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2.Manager;

namespace WebApi2.Controllers
{
    public class RedisController : ApiController
    {
        // GET: api/Redis/name
        public int Get(string name)
        {

            RedisClient client = new RedisClient("localhost", 6379);
            
            CacheManager cacheManager = new CacheManager(client);
            Person person = cacheManager.Get<Person>(name);

            return person.Age;
        }

        // POST: api/Redis
        public void Post(int age, string name)
        {
            RedisClient client = new RedisClient("localhost", 6379);
           
            CacheManager cacheManager = new CacheManager(client);
            Person person = new Person();
            person.Age = age;
            person.Name = name;

            cacheManager.Set(person);
        }        
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
