using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taxi_NET_API.Models;
using Taxi_NET_API.Services.CombustionTaxiService;

namespace Taxi_NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricTaxiController : ControllerBase
    {
        private readonly IElectricTaxiService _electricTaxiService;
        

        public ElectricTaxiController(IElectricTaxiService electricTaxiService)
        {
            _electricTaxiService = electricTaxiService;
        }

        // GET: api/ElectricTaxi
        [HttpGet]
         public async Task<ActionResult<List<ElectricTaxi>>> GetElectricTaxis()
        {
          var result = await _electricTaxiService.GetElectricTaxis();
          if (result == null)
          {
            return  NotFound("Electric Taxis not found :c");
          }
          return Ok(result);
        }

        // GET: api/ElectricTaxi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ElectricTaxi>> GetElectricTaxi(int id)
        {
          
            var result = await _electricTaxiService.GetElectricTaxi(id);

            if (result == null)
            {
                return NotFound("Taxi with that id not found :c");
            }

            return Ok(result);
        }

        // PUT: api/ElectricTaxi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<List<ElectricTaxi>>> PutElectricTaxi(int id, ElectricTaxi electricTaxi)
        {
           var result = await _electricTaxiService.PutElectricTaxi(id,electricTaxi);
           if (result == null)
            {
                return NotFound("Taxi with that id not found :c");
            }

            return Ok(result);
        }

        // POST: api/ElectricTaxi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
         public async Task<ActionResult<List<ElectricTaxi>>> PostElectricTaxi(ElectricTaxi electricTaxi)
        {
         var result = await _electricTaxiService.PostElectricTaxi(electricTaxi); 
         return Ok(result);
        }

        // DELETE: api/ElectricTaxi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ElectricTaxi>>> DeleteElectricTaxi(int id)
        {
           var result = await _electricTaxiService.DeleteElectricTaxi(id);
            if (result == null)
            {
                return NotFound("Electric taxi with that id not found :c ");
            }
            return Ok(result);

        }

    }
}
