using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using angularjs_crud_sample.Models;

namespace angularjs_crud_sample.Controllers
{
    public class FriendController : ApiController
    {
        private FriendsContext db = new FriendsContext();
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Friend> Get()         
        {
            return db.Friends.AsEnumerable();
        }

        // GET api/<controller>/5
        public Friend Get(int id)
        {
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return friend;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Friend friend)
        {
            if (ModelState.IsValid)
            {
                db.Friends.Add(friend);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, friend);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = friend.FriendId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Friend friend)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != friend.FriendId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(friend).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Friends.Remove(friend);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, friend);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}