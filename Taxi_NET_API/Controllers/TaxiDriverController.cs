using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taxi_NET_API.Models;
using Taxi_NET_API.Data;

namespace Taxi_NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiDriverController : ControllerBase
    {
        private readonly DataContext _context;

        public TaxiDriverController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TaxiDriver
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxiDriver>>> GetTaxiDrivers()
        {
          if (_context.TaxiDrivers == null)
          {
              return NotFound();
          }
            return await _context.TaxiDrivers.ToListAsync();
        }

        // GET: api/TaxiDriver/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxiDriver>> GetTaxiDriver(int id)
        {
          if (_context.TaxiDrivers == null)
          {
              return NotFound();
          }
            var taxiDriver = await _context.TaxiDrivers.FindAsync(id);

            if (taxiDriver == null)
            {
                return NotFound();
            }

            return taxiDriver;
        }

        // PUT: api/TaxiDriver/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxiDriver(int id, TaxiDriver taxiDriver)
        {
            if (id != taxiDriver.TaxiDriverID)
            {
                return BadRequest();
            }

            _context.Entry(taxiDriver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxiDriverExists(id))
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

        // POST: api/TaxiDriver
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaxiDriver>> PostTaxiDriver(TaxiDriver taxiDriver)
        {
          if (_context.TaxiDrivers == null)
          {
              return Problem("Entity set 'TaxiDriverContext.TaxiDrivers'  is null.");
          }
            _context.TaxiDrivers.Add(taxiDriver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaxiDriver", new { id = taxiDriver.TaxiDriverID }, taxiDriver);
        }

        // DELETE: api/TaxiDriver/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxiDriver(int id)
        {
            if (_context.TaxiDrivers == null)
            {
                return NotFound();
            }
            var taxiDriver = await _context.TaxiDrivers.FindAsync(id);
            if (taxiDriver == null)
            {
                return NotFound();
            }

            _context.TaxiDrivers.Remove(taxiDriver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaxiDriverExists(int id)
        {
            return (_context.TaxiDrivers?.Any(e => e.TaxiDriverID == id)).GetValueOrDefault();
        }
    }
}
