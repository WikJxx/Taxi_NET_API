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
    public class CombustionTaxiController : ControllerBase
    {
        private readonly DataContext _context;

        public CombustionTaxiController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CombustionTaxi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CombustionTaxi>>> GetCombustionTaxis()
        {
          if (_context.CombustionTaxis == null)
          {
              return NotFound();
          }
            return await _context.CombustionTaxis.ToListAsync();
        }

        // GET: api/CombustionTaxi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CombustionTaxi>> GetCombustionTaxi(int id)
        {
          if (_context.CombustionTaxis == null)
          {
              return NotFound();
          }
            var combustionTaxi = await _context.CombustionTaxis.FindAsync(id);

            if (combustionTaxi == null)
            {
                return NotFound();
            }

            return combustionTaxi;
        }

        // PUT: api/CombustionTaxi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCombustionTaxi(int id, CombustionTaxi combustionTaxi)
        {
            if (id != combustionTaxi.CombustionTaxiID)
            {
                return BadRequest();
            }

            _context.Entry(combustionTaxi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CombustionTaxiExists(id))
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

        // POST: api/CombustionTaxi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CombustionTaxi>> PostCombustionTaxi(CombustionTaxi combustionTaxi)
        {
          if (_context.CombustionTaxis == null)
          {
              return Problem("Entity set 'CombustionTaxiContext.CombustionTaxis'  is null.");
          }
            _context.CombustionTaxis.Add(combustionTaxi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCombustionTaxi", new { id = combustionTaxi.CombustionTaxiID }, combustionTaxi);
        }

        // DELETE: api/CombustionTaxi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCombustionTaxi(int id)
        {
            if (_context.CombustionTaxis == null)
            {
                return NotFound();
            }
            var combustionTaxi = await _context.CombustionTaxis.FindAsync(id);
            if (combustionTaxi == null)
            {
                return NotFound();
            }

            _context.CombustionTaxis.Remove(combustionTaxi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CombustionTaxiExists(int id)
        {
            return (_context.CombustionTaxis?.Any(e => e.CombustionTaxiID == id)).GetValueOrDefault();
        }
    }
}
