using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCoreExtentions
{
    [Route("api/[controller]")]
    public class LibraryAPI : Controller
    {
        LibraryDetails[] LibraryDetails = new LibraryDetails[]
        {
            new LibraryDetails { Id=1, BookName="Programming C# for Beginners", Author="Mahesh Chand", Category="C#" },
            new LibraryDetails { Id=2, BookName="Setting Up SharePoint 2016 Multi-Server Farm In Azure", Author="Priyaranjan K S", Category="SharePoint" },
            new LibraryDetails { Id=3, BookName="SQL Queries For Beginners", Author="Syed Shanu", Category="Sql" },
            new LibraryDetails { Id=4, BookName="OOPs Principle and Theory", Author="Syed Shanu", Category="Basic Concepts" },
            new LibraryDetails { Id=5, BookName="ASP.NET GridView Control Pocket Guide", Author="Vincent Maverick Durano", Category="Asp.Net" }
        };
        
        // GET: api/values
        [HttpGet]
        public IEnumerable<LibraryDetails> GetAllBooks()
        {
            return LibraryDetails;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var books = LibraryDetails.FirstOrDefault((p) => p.Id == id);

            var item = books;
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
