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
    [Route("api/sessions")]
    public class SessionModelsController : Controller
    {
        private readonly MoviesContext _context;

        public SessionModelsController(MoviesContext context)
        {
            _context = context;
        }

        //Orders results by Descending order of the Time the Movie is Running
        // GET: api/sessions
        [HttpGet]
        public IEnumerable<SessionModel> GetSessionModel()
        {
            return _context.SessionModel.OrderBy(c => c.TimeRunning);
        }

        // GET: api/sessions/location/id
        [HttpGet]
        [Route("location/{location}")]
        public IEnumerable<SessionModel> GetByLocation(int location)
        {
            return _context.SessionModel.OrderBy(c => c.TimeRunning).Where(c => c.CineplexID == location);
        }
        // GET: api/sessions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SessionModel sessionModel = await _context.SessionModel.SingleOrDefaultAsync(m => m.SessionID == id);

            if (sessionModel == null)
            {
                return NotFound();
            }

            return Ok(sessionModel);
        }

        private bool SessionModelExists(int id)
        {
            return _context.SessionModel.Any(e => e.SessionID == id);
        }
    }
}