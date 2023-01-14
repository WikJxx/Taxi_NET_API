// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Taxi_NET_API.Data;
// using Taxi_NET_API.Models;

// namespace Taxi_NET_API.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class DriverChoiceController : ControllerBase
//     {
//         private readonly DataContext _context;

//         public DriverChoiceController(DataContext context)
//         {
//             _context = context;
//         }

//         // GET: api/DriverChoice
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<DriverChoice>>> GetDriverChoice()
//         {
//           if (_context.DriverChoice == null)
//           {
//               return NotFound();
//           }
//             return await _context.DriverChoice.ToListAsync();
//         }

//         // GET: api/DriverChoice/5
//         [HttpGet("{id}")]
//         public async Task<ActionResult<DriverChoice>> GetDriverChoice(int id)
//         {
//           if (_context.DriverChoice == null)
//           {
//               return NotFound();
//           }
//             var driverChoice = await _context.DriverChoice.FindAsync(id);

//             if (driverChoice == null)
//             {
//                 return NotFound();
//             }

//             return driverChoice;
//         }

//         // PUT: api/DriverChoice/5
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutDriverChoice(int id, DriverChoice driverChoice)
//         {
//             if (id != driverChoice.DriverChoiceID)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(driverChoice).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!DriverChoiceExists(id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }

//             return NoContent();
//         }

//         // POST: api/DriverChoice
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPost]
//         public async Task<ActionResult<DriverChoice>> PostDriverChoice(DriverChoice driverChoice)
//         {
//           if (_context.DriverChoice == null)
//           {
//               return Problem("Entity set 'DataContext.DriverChoice'  is null.");
//           }
//             _context.DriverChoice.Add(driverChoice);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction("GetDriverChoice", new { id = driverChoice.DriverChoiceID }, driverChoice);
//         }

//         // DELETE: api/DriverChoice/5
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteDriverChoice(int id)
//         {
//             if (_context.DriverChoice == null)
//             {
//                 return NotFound();
//             }
//             var driverChoice = await _context.DriverChoice.FindAsync(id);
//             if (driverChoice == null)
//             {
//                 return NotFound();
//             }

//             _context.DriverChoice.Remove(driverChoice);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }

//         private bool DriverChoiceExists(int id)
//         {
//             return (_context.DriverChoice?.Any(e => e.DriverChoiceID == id)).GetValueOrDefault();
//         }
//     }
// }
