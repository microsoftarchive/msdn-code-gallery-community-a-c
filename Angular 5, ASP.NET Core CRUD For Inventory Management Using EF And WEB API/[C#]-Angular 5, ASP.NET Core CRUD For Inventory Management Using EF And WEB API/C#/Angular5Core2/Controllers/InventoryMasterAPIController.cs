using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Angular5Core2.Data;

using Microsoft.EntityFrameworkCore;

namespace Angular5Core2.Controllers
{
    [Produces("application/json")]
    [Route("api/InventoryMasterAPI")]
    public class InventoryMasterAPIController : Controller
    {
		private readonly InventoryContext _context;

		public InventoryMasterAPIController(InventoryContext context)
		{
			_context = context;
		}

		// GET: api/InventoryMasterAPI

		[HttpGet]
		[Route("Inventory")]
		public IEnumerable<InventoryMaster> GetInventoryMaster()
		{
			return _context.InventoryMaster;

		}


		// POST: api/InventoryMasterAPI
		[HttpPost]
		public async Task<IActionResult> PostInventoryMaster([FromBody] InventoryMaster InventoryMaster)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_context.InventoryMaster.Add(InventoryMaster);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (InventoryMasterExists(InventoryMaster.InventoryID))
				{
					return new StatusCodeResult(StatusCodes.Status409Conflict);
				}
				else
				{
					throw;
				}
			}

			return CreatedAtAction("GetInventoryMaster", new { id = InventoryMaster.InventoryID }, InventoryMaster);
		}
		private bool InventoryMasterExists(int id)
		{
			return _context.InventoryMaster.Any(e => e.InventoryID == id);
		}



		// PUT: api/InventoryMasterAPI/2
		[HttpPut("{id}")]
		public async Task<IActionResult> PutInventoryMaster([FromRoute] int id, [FromBody] InventoryMaster InventoryMaster)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != InventoryMaster.InventoryID)
			{
				return BadRequest();
			}

			_context.Entry(InventoryMaster).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!InventoryMasterExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}


		// DELETE: api/InventoryMasterAPI/2
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteInventoryMaster([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			InventoryMaster InventoryMaster = await _context.InventoryMaster.SingleOrDefaultAsync(m => m.InventoryID == id);
			if (InventoryMaster == null)
			{
				return NotFound();
			}

			_context.InventoryMaster.Remove(InventoryMaster);
			await _context.SaveChangesAsync();

			return Ok(InventoryMaster);
		}
	}
}