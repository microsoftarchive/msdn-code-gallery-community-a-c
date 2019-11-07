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
    [Route("api/movies")]
    public class MovieModelsController : Controller
    {
        private readonly MoviesContext _context;

        public MovieModelsController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/movies
        [HttpGet]
        public IEnumerable<MovieModel> GetMovieModel()
        {
            return _context.MovieModel;
        }

        // GET: api/movies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MovieModel movieModel = await _context.MovieModel.SingleOrDefaultAsync(m => m.MovieId == id);

            if (movieModel == null)
            {
                return NotFound();
            }

            return Ok(movieModel);
        }

        private bool MovieModelExists(int id)
        {
            return _context.MovieModel.Any(e => e.MovieId == id);
        }
    }
}