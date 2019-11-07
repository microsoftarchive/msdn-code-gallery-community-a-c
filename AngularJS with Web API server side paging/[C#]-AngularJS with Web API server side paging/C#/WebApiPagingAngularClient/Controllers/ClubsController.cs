using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPagingAngularClient.Models;
using WebApiPagingAngularClient.Utility;

namespace WebApiPagingAngularClient.Controllers
{
    [RoutePrefix("api/clubs")]
    public class ClubsController : ApiController
    {
        private ClubRepository clubRepository;

        public ClubsController(): this(new ClubRepository())
        {

        }

        public ClubsController(ClubRepository repository)
        {
            this.clubRepository = repository;
        }

        // GET: api/Clubs
        [Route("")]
        public IHttpActionResult Get()
        {
            var clubs = this.clubRepository.Clubs.ToList();

            return Ok(clubs);
        }

        // GET: api/Clubs/5
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var club = this.clubRepository.Clubs.FirstOrDefault(c => c.Id == id);

            return Ok(club);
        }

        // GET: api/Clubs/clubName
        [Route("{name:alpha}")]
        public IHttpActionResult Get(string name)
        {
            var club = this.clubRepository.Clubs.FirstOrDefault(c => c.Name == name);

            return Ok(club);
        }

        // GET: api/Clubs/pageSize/pageNumber/orderBy(optional)
        [Route("{pageSize:int}/{pageNumber:int}/{orderBy:alpha?}")]
        public IHttpActionResult Get(int pageSize, int pageNumber, string orderBy = "")
        {
            var totalCount = this.clubRepository.Clubs.Count();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);
            var clubQuery = this.clubRepository.Clubs;

            if (QueryHelper.PropertyExists<Club>(orderBy))
            {
                var orderByExpression = QueryHelper.GetPropertyExpression<Club>(orderBy);
                clubQuery = clubQuery.OrderBy(orderByExpression);
            } else
            {
                clubQuery = clubQuery.OrderBy(c => c.Id);
            }

            var clubs = clubQuery.Skip((pageNumber - 1) * pageSize)                            
                                    .Take(pageSize)                
                                    .ToList();

            var result = new
            {
                TotalCount = totalCount,
                totalPages = totalPages,
                Clubs = clubs
            };

            return Ok(result);
        }
      
        // POST: api/Clubs
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clubs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clubs/5
        public void Delete(int id)
        {
        }
    }
}
