using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaPlex.Data;
using CinemaPlex.Models;

namespace CinemaPlex.Controllers
{
    [Produces("application/json")]
    [Route("api/cinemas")]
    public class CinemaModelsController : Controller
    {
        private readonly MoviesContext _context;

        public CinemaModelsController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/cinemas
        [HttpGet]
        public IEnumerable<CinemaModel> GetCinemaModel()
        {
            return _context.CinemaModel;
        }

        // GET: api/cinemas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCinemaModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CinemaModel cinemaModel = await _context.CinemaModel.SingleOrDefaultAsync(m => m.CineplexID == id);

            if (cinemaModel == null)
            {
                return NotFound();
            }

            return Ok(cinemaModel);
        }

        private bool CinemaModelExists(int id)
        {
            return _context.CinemaModel.Any(e => e.CineplexID == id);
        }
    }
}