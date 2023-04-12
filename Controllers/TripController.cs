using Microsoft.AspNetCore.Mvc;

namespace Taxi_NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;
        

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
         public async Task<ActionResult<List<Trip>>> GetTrip()
        {
          var result = await _tripService.GetTrips();
          if (result == null)
          {
            return  NotFound("Trips not found :c");
          }
          return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetTrip(int id)
        {
          
            var result = await _tripService.GetTrip(id);

            if (result == null)
            {
                return NotFound("Trip with that id not found :c");
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Trip>>> PutTrip(int id, Trip trip)
        {
           var result = await _tripService.PutTrip(id, trip);
           if (result == null)
            {
                return NotFound("Trip with that id not found :c");
            }

            return Ok(result);
        }

        [HttpPost]
         public async Task<ActionResult<List<Trip>>> PostTrip(Trip trip)
        {
         var result = await _tripService.PostTrip(trip); 
         return Ok(result);
        }

     
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Trip>>> DeleteTrip(int id)
        {
           var result = await _tripService.DeleteTrip(id);
            if (result == null)
            {
                return NotFound("Trip with that id not found :c ");
            }
            return Ok(result);

        }

    }
}
