using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPCoreAngular2Shopping.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPCoreAngular2Shopping.Controllers
{
	[Produces("application/json")]
	[Route("api/ItemDetailsAPI")] 
    public class ItemDetailsAPI : Controller
    {
		private readonly ItemContext _context;

		public ItemDetailsAPI(ItemContext context)
		{
			_context = context;
		}

		// GET: api/values

		[HttpGet]
		[Route("Details")]
		public IEnumerable<ItemDetails> GetItemDetails()
		{
			return _context.ItemDetails;

		}


		// GET api/values/5
		[HttpGet]
		[Route("Details/{ItemName}")]
		public IEnumerable<ItemDetails> GetItemDetails(string ItemName)
		{
			//return _context.ItemDetails.Where(i => i.Item_ID == id).ToList(); ;
			return _context.ItemDetails.Where(i => i.Item_Name.Contains(ItemName)).ToList(); 
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
