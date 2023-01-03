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
    public class ElectricTaxiController : ControllerBase
    {
        private readonly ElectricTaxiContext _context;

        public ElectricTaxiController(ElectricTaxiContext context)
        {
            _context = context;
        }

        // GET: api/ElectricTaxi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElectricTaxi>>> GetElectricTaxis()
        {
          if (_context.ElectricTaxis == null)
          {
              return NotFound();
          }
            return await _context.ElectricTaxis.ToListAsync();
        }

        // GET: api/ElectricTaxi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ElectricTaxi>> GetElectricTaxi(int id)
        {
          if (_context.ElectricTaxis == null)
          {
              return NotFound();
          }
            var electricTaxi = await _context.ElectricTaxis.FindAsync(id);

            if (electricTaxi == null)
            {
                return NotFound();
            }

            return electricTaxi;
        }

        // PUT: api/ElectricTaxi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElectricTaxi(int id, ElectricTaxi electricTaxi)
        {
            if (id != electricTaxi.electricTaxiID)
            {
                return BadRequest();
            }

            _context.Entry(electricTaxi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectricTaxiExists(id))
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

        // POST: api/ElectricTaxi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ElectricTaxi>> PostElectricTaxi(ElectricTaxi electricTaxi)
        {
          if (_context.ElectricTaxis == null)
          {
              return Problem("Entity set 'ElectricTaxiContext.ElectricTaxis'  is null.");
          }
            _context.ElectricTaxis.Add(electricTaxi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElectricTaxi", new { id = electricTaxi.electricTaxiID }, electricTaxi);
        }

        // DELETE: api/ElectricTaxi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElectricTaxi(int id)
        {
            if (_context.ElectricTaxis == null)
            {
                return NotFound();
            }
            var electricTaxi = await _context.ElectricTaxis.FindAsync(id);
            if (electricTaxi == null)
            {
                return NotFound();
            }

            _context.ElectricTaxis.Remove(electricTaxi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElectricTaxiExists(int id)
        {
            return (_context.ElectricTaxis?.Any(e => e.electricTaxiID == id)).GetValueOrDefault();
        }
    }
}
