using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taxi_NET_API.Models;

namespace Taxi_NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly DataContext _context;

        public TripController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Trip
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trip>>> GetTrips()
        {
          if (_context.Trips == null)
          {
              return NotFound();
          }
            return await _context.Trips.ToListAsync();
        }

        // GET: api/Trip/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetTrip(int id)
        {
          if (_context.Trips == null)
          {
              return NotFound();
          }
            var trip = await _context.Trips.FindAsync(id);

            if (trip == null)
            {
                return NotFound();
            }

            return trip;
        }

    
        // POST: api/Trip
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trip>> PostTrip(Trip trip)
        {
          if (_context.Trips == null)
          {
              return Problem("Entity set 'TripContext.Trips'  is null.");
          }
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrip", new { id = trip.TripID }, trip);
        }

        // DELETE: api/Trip/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            if (_context.Trips == null)
            {
                return NotFound();
            }
            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TripExists(int id)
        {
            return (_context.Trips?.Any(e => e.TripID == id)).GetValueOrDefault();
        }
    }
}
