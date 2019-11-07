using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Angular2AspCoreMasterDetail.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Angular2AspCoreMasterDetail.Controllers
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

		// GET: api/values

		[HttpGet]
		[Route("Details")]
		public IEnumerable<StudentDetails> GetStudentDetails()
		{
			return _context.StudentDetails;

		}


		// GET api/values/5
		[HttpGet]
		[Route("Details/{id}")]
		public IEnumerable<StudentDetails> GetStudentDetails(int id)
		{
			return _context.StudentDetails.Where(i => i.StdID == id).ToList(); ;
		}
	}
}
