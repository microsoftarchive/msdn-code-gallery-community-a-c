using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Angular2ASPCORE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Angular2ASPCORE.Controllers
{
	[Produces("application/json")]
	[Route("api/StudentMastersAPI")]
	public class StudentMastersAPI : Controller
    {
		private readonly studentContext _context;

		public StudentMastersAPI(studentContext context)
		{
			_context = context;
		}

		// GET: api/values

		[HttpGet]
		[Route("Student")]
		public IEnumerable<StudentMasters> GetStudentMasters()
		{
			return _context.StudentMasters;

		}


		// POST: api/StudentMastersAPI
		[HttpPost]
		public async Task<IActionResult> PostStudentMasters([FromBody] StudentMasters studentMasters)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_context.StudentMasters.Add(studentMasters);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (StudentMastersExists(studentMasters.StdID))
				{
					return new StatusCodeResult(StatusCodes.Status409Conflict);
				}
				else
				{
					throw;
				}
			}

			return CreatedAtAction("GetStudentMasters", new { id = studentMasters.StdID }, studentMasters);
		}
		private bool StudentMastersExists(int id)
		{
			return _context.StudentMasters.Any(e => e.StdID == id);
		}



		// PUT: api/StudentMastersAPI/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutStudentMasters([FromRoute] int id, [FromBody] StudentMasters studentMasters)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != studentMasters.StdID)
			{
				return BadRequest();
			}

			_context.Entry(studentMasters).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!StudentMastersExists(id))
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


		// DELETE: api/StudentMastersAPI/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteStudentMasters([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			StudentMasters studentMasters = await _context.StudentMasters.SingleOrDefaultAsync(m => m.StdID == id);
			if (studentMasters == null)
			{
				return NotFound();
			}

			_context.StudentMasters.Remove(studentMasters);
			await _context.SaveChangesAsync();

			return Ok(studentMasters);
		} 
	}
}