using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiUniqueConstraintHandling.Models;

namespace WebApiUniqueConstraintHandling.Controllers
{    
    public class BooksController : ApiController
    {
        private SampleContext db = new SampleContext("bookConn");

        //POST: api/books/titleAvailable
        [HttpPost]
        [ResponseType(typeof(bool))]
        [Route("api/books/titleavailable")]
        public async Task<IHttpActionResult> TitleAvailable(TitleAvailableBindingModel query)
        {

            System.Threading.Thread.Sleep(2000); //slow down the response to see the async checking validation working

            var titleTaken = await db.Books.AnyAsync(b => query.Title.ToLower() == b.Title.ToLower());

            return Ok(new { titleAvailable = !titleTaken });            
        }

        // GET: api/Books       
        public async Task<IHttpActionResult> Get()
        {
            var books = await db.Books.ToListAsync();
            return Ok(books);
        }

        // GET: api/Books/5
        //[ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> Get(int id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Put(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> Post(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);

            try
            {
                await db.SaveChangesAsync();                
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            await db.SaveChangesAsync();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.Id == id) > 0;
        }
    }
}