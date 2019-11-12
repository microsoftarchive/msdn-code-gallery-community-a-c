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
 
	}
}