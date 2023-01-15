using Microsoft.AspNetCore.Mvc;


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
 
        [HttpPost]
         public async Task<ActionResult<List<ElectricTaxi>>> PostElectricTaxi(ElectricTaxi electricTaxi)
        {
         var result = await _electricTaxiService.PostElectricTaxi(electricTaxi); 
         return Ok(result);
        }

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
