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
    public class AssingmentController : ControllerBase
    {
        private readonly AssingmentContext _context;

        public AssingmentController(AssingmentContext context)
        {
            _context = context;
        }

        // GET: api/Assingment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assingment>>> GetAssingments()
        {
          if (_context.Assingments == null)
          {
              return NotFound();
          }
            return await _context.Assingments.ToListAsync();
        }

        // GET: api/Assingment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assingment>> GetAssingment(int id)
        {
          if (_context.Assingments == null)
          {
              return NotFound();
          }
            var assingment = await _context.Assingments.FindAsync(id);

            if (assingment == null)
            {
                return NotFound();
            }

            return assingment;
        }

        // PUT: api/Assingment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssingment(int id, Assingment assingment)
        {
            if (id != assingment.AssingmentID)
            {
                return BadRequest();
            }

            _context.Entry(assingment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssingmentExists(id))
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

        // POST: api/Assingment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Assingment>> PostAssingment(Assingment assingment)
        {
          if (_context.Assingments == null)
          {
              return Problem("Entity set 'AssingmentContext.Assingments'  is null.");
          }
            _context.Assingments.Add(assingment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssingment", new { id = assingment.AssingmentID }, assingment);
        }

        // DELETE: api/Assingment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssingment(int id)
        {
            if (_context.Assingments == null)
            {
                return NotFound();
            }
            var assingment = await _context.Assingments.FindAsync(id);
            if (assingment == null)
            {
                return NotFound();
            }

            _context.Assingments.Remove(assingment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssingmentExists(int id)
        {
            return (_context.Assingments?.Any(e => e.AssingmentID == id)).GetValueOrDefault();
        }
    }
}
