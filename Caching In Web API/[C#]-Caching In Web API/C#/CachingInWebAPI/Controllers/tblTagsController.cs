using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CachingInWebAPI.Models;
using System.Runtime.Caching;
namespace CachingInWebAPI.Controllers
{
    public class tblTagsController : ApiController
    {
        private TrialsDBEntities db = new TrialsDBEntities();
        MemoryCache memCache = MemoryCache.Default;
        // GET: api/tblTags
        public object GettblTags()
        {
            var res = memCache.Get("tag");
            if (res != null)
            {
                //This is to remove the MemoryCache - start
                if (memCache.Contains("tag"))
                {
                    memCache.Remove("tag");
                }
                //This is to remove the MemoryCache - end
                return res;
            }
            else {
                var ca = db.tblTags;
                memCache.Add("tag", ca, DateTimeOffset.UtcNow.AddMinutes(5));
                return db.tblTags;
            }
        }

        // GET: api/tblTags/5
        [ResponseType(typeof(tblTag))]
        public IHttpActionResult GettblTag(int id)
        {
            tblTag tblTag = db.tblTags.Find(id);
            if (tblTag == null)
            {
                return NotFound();
            }

            return Ok(tblTag);
        }

        // PUT: api/tblTags/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblTag(int id, tblTag tblTag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblTag.tagId)
            {
                return BadRequest();
            }

            db.Entry(tblTag).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblTagExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tblTags
        [ResponseType(typeof(tblTag))]
        public IHttpActionResult PosttblTag(tblTag tblTag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblTags.Add(tblTag);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblTag.tagId }, tblTag);
        }

        // DELETE: api/tblTags/5
        [ResponseType(typeof(tblTag))]
        public IHttpActionResult DeletetblTag(int id)
        {
            tblTag tblTag = db.tblTags.Find(id);
            if (tblTag == null)
            {
                return NotFound();
            }

            db.tblTags.Remove(tblTag);
            db.SaveChanges();

            return Ok(tblTag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblTagExists(int id)
        {
            return db.tblTags.Count(e => e.tagId == id) > 0;
        }
    }
}