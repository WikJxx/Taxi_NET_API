using Microsoft.AspNetCore.Mvc;

namespace Taxi_NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiDriverController : ControllerBase
    {
        private readonly ITaxiDriverService _taxiDriverService;
        

        public TaxiDriverController(ITaxiDriverService taxiDriverService)
        {
            _taxiDriverService = taxiDriverService;
        }

        [HttpGet]
         public async Task<ActionResult<List<TaxiDriver>>> GetTaxiDriver()
        {
          var result = await _taxiDriverService.GetTaxiDrivers();
          if (result == null)
          {
            return  NotFound("Taxi Drivers not found :c");
          }
          return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaxiDriver>> GetTaxiDriver(int id)
        {
          
            var result = await _taxiDriverService.GetTaxiDriver(id);

            if (result == null)
            {
                return NotFound("Driver with that id not found :c");
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TaxiDriver>>> PutTaxiDriver(int id, TaxiDriver taxiDriver)
        {
           var result = await _taxiDriverService.PutTaxiDriver(id, taxiDriver);
           if (result == null)
            {
                return NotFound("Driver with that id not found :c");
            }

            return Ok(result);
        }

        [HttpPost]
         public async Task<ActionResult<List<TaxiDriver>>> PostTaxiDriver(TaxiDriver taxiDriver)
        {
         var result = await _taxiDriverService.PostTaxiDriver(taxiDriver); 
         return Ok(result);
        }

     
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TaxiDriver>>> DeleteTaxiDriver(int id)
        {
           var result = await _taxiDriverService.DeleteTaxiDriver(id);
            if (result == null)
            {
                return NotFound("Taxi driver with that id not found :c ");
            }
            return Ok(result);

        }
    }
}
