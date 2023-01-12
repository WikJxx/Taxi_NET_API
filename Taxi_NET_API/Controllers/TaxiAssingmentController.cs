using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taxi_NET_API.Data;
using Taxi_NET_API.Models;

namespace Taxi_NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiAssingmentController : ControllerBase
    {
        private readonly DataContext _context;

        public TaxiAssingmentController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TaxiAssingment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxiAssingment>>> GetTaxiAssingments()
        {
          if (_context.TaxiAssingments == null)
          {
              return NotFound();
          }
            return await _context.TaxiAssingments.ToListAsync();
        }

        // GET: api/TaxiAssingment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxiAssingment>> GetTaxiAssingment(int id)
        {
          if (_context.TaxiAssingments == null)
          {
              return NotFound();
          }
            var taxiAssingment = await _context.TaxiAssingments.FindAsync(id);

            if (taxiAssingment == null)
            {
                return NotFound();
            }

            return taxiAssingment;
        }

        // PUT: api/TaxiAssingment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxiAssingment(int id, TaxiAssingment taxiAssingment)
        {
            if (id != taxiAssingment.TaxiAssingmentID)
            {
                return BadRequest();
            }

            _context.Entry(taxiAssingment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxiAssingmentExists(id))
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

        // POST: api/TaxiAssingment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaxiAssingment>> PostTaxiAssingment(TaxiAssingment taxiAssingment)
        {
          if (_context.TaxiAssingments == null)
          {
              return Problem("Entity set 'DataContext.TaxiAssingments'  is null.");
          }
            _context.TaxiAssingments.Add(taxiAssingment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaxiAssingment", new { id = taxiAssingment.TaxiAssingmentID }, taxiAssingment);
        }

        // DELETE: api/TaxiAssingment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxiAssingment(int id)
        {
            if (_context.TaxiAssingments == null)
            {
                return NotFound();
            }
            var taxiAssingment = await _context.TaxiAssingments.FindAsync(id);
            if (taxiAssingment == null)
            {
                return NotFound();
            }

            _context.TaxiAssingments.Remove(taxiAssingment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaxiAssingmentExists(int id)
        {
            return (_context.TaxiAssingments?.Any(e => e.TaxiAssingmentID == id)).GetValueOrDefault();
        }
    }
}
