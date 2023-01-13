using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Taxi_NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombustionTaxiController : ControllerBase
    {
        private readonly ICombustionTaxiService _combustionTaxiService;

        public CombustionTaxiController(ICombustionTaxiService combustionTaxiService)
        {
            _combustionTaxiService = combustionTaxiService;
        }

        // GET: api/CombustionTaxi
        [HttpGet]
        public async Task<ActionResult<List<CombustionTaxi>>> GetCombustionTaxis()
        {
          var result = await _combustionTaxiService.GetCombustionTaxis();
          if (result == null)
          {
            return  NotFound("Combustion Taxis not found :c");
          }
          return Ok(result);
        }

        // GET: api/CombustionTaxi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CombustionTaxi>> GetCombustionTaxi(int id)
        {
          
            var result = await _combustionTaxiService.GetCombustionTaxi(id);

            if (result == null)
            {
                return NotFound("Taxi with that id not found :c");
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<CombustionTaxi>>> PutCombustionTaxi(int id, CombustionTaxi combustionTaxi)
        {
           var result = await _combustionTaxiService.PutCombustionTaxi(id,combustionTaxi);
           if (result == null)
            {
                return NotFound("Taxi with that id not found :c");
            }

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<ActionResult<List<CombustionTaxi>>> PostCombustionTaxi(CombustionTaxi combustionTaxi)
        {
         var result = await _combustionTaxiService.PostCombustionTaxi(combustionTaxi); 
         return Ok(result);
        }

        // DELETE: api/CombustionTaxi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CombustionTaxi>>> DeleteCombustionTaxi(int id)
        {
           var result = await _combustionTaxiService.DeleteCombustionTaxi(id);
            if (result == null)
            {
                return NotFound("Combustion taxi with that id not found :c ");
            }
            return Ok(result);

        }

      
    }
}
