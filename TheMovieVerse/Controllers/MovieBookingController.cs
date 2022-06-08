using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheMovieVerse.DB;
using TheMovieVerse.Model;

namespace TheMovieVerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieBookingController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public MovieBookingController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieBooking
        [HttpGet("CheckAllBookings")]
        public async Task<ActionResult<IEnumerable<MovieBooking>>> GetMovieBookings()
        {
            return await _context.MovieBookings.ToListAsync();
        }

        // GET: api/MovieBooking/5
        [HttpGet("CheckYourBookingDetails{id}")]
        public async Task<ActionResult<MovieBooking>> GetMovieBooking(long id)
        {
            var movieBooking = await _context.MovieBookings.FindAsync(id);

            if (movieBooking == null)
            {
                return NotFound();
            }

            return movieBooking;
        }

        // POST: api/MovieBooking
        [HttpPost("BookYourTicket")]
        public async Task<ActionResult<MovieBooking>> PostMovieBooking(MovieBooking movieBooking)
        {
            _context.MovieBookings.Add(movieBooking);
            //for (int i = 0; i <= movieBooking.NoOfTickets; i++)
            //{
            //   // movieBooking.Seats;
            //}

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieBooking", new { id = movieBooking.Id }, movieBooking);
        }

        private bool MovieBookingExists(long id)
        {
            return _context.MovieBookings.Any(e => e.Id == id);
        }
    }
}
