using ODataV4Sample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;

namespace ODataV4Sample.Controllers
{
    public class PeopleController : ODataController
    {
        private PeopleRepository repository = new PeopleRepository();

        public IHttpActionResult Get(ODataQueryOptions<Person> options)
        {
            var skip = options.Skip == null ? null : (int?)options.Skip.Value;
            var top = options.Top == null ? null : (int?)options.Top.Value;
            var results = repository.GetPeople(skip, top);
            if (!results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }

        public IHttpActionResult Get(int key)
        {
            var response = this.repository.Get(key);
            if (repository == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        public IHttpActionResult Patch(int key, Delta<Person> delta)
        {
            var p = this.repository.Get(key);
            if (p == null) { return NotFound(); }

            delta.Patch(p);
            if (!this.repository.Update(key, p))
            {
                return NotFound();
            }

            return Updated(p);
        }

        public IHttpActionResult Put(int key, Person p)
        {
            if (!this.repository.Update(key, p)) { return NotFound(); }
            return Updated(p);
        }

        public IHttpActionResult Post(Person p)
        {
            var newId = this.repository.Add(p);
            return Created(this.repository.Get(newId));
        }

        public IHttpActionResult Delete(int key)
        {
            if (!this.repository.Delete(key)) { return NotFound(); }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET ODataV4Sample.Analyze(skip={skip},top={top})
        [HttpGet]
        public IHttpActionResult Analyze(int skip, int top)
        {
            var people = this.repository.GetPeople(skip, top);
            var average = people.Select(x => x.Age)
                .Average();
            var max = people.Max(p => p.Age);
            var min = people.Min(p => p.Age);
            return Ok(new AnalyzeResult { Average = average, MaxAge = max, MinAge = min });
        }

        // POST ODataV4Sample.Age
        [HttpPost]
        public IHttpActionResult Age(ODataActionParameters parameter)
        {
            var p = (AgeParameter)parameter["p"];
            var people = this.repository.GetPeople(p.Skip, p.Top);
            foreach (var person in people)
            {
                var target = this.repository.Get(person.Id);
                target.Age += p.Age;
                this.repository.Update(person.Id, target);
            }
            return Ok();
        }
    }
}