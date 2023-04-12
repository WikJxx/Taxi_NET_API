using Microsoft.AspNetCore.Mvc;

namespace Taxi_NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverChoiceController : ControllerBase
    {
        private readonly IDriverChoiceService _driverChoiceService;

        public DriverChoiceController(IDriverChoiceService driverChoiceService)
        {
            _driverChoiceService = driverChoiceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DriverChoice>>> GetDriverChoices()
        {
          var result = await _driverChoiceService.GetDriverChoices();
          if (result == null)
          {
            return  NotFound("Driver choices not found :c");
          }
          return Ok(result);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<DriverChoice>> GetDriverChoice(int id)
        {
           var result = await _driverChoiceService.GetDriverChoice(id);

            if (result == null)
            {
                return NotFound("Driver choice with that id not found :c");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<DriverChoice>> ExecuteDriverChoice(DriverChoice driverChoice)
        {
          var result = await _driverChoiceService.ExecuteDriverChoice(driverChoice); 
          if (result == null)
            {
                return NotFound("Driver choice couldn't be executed ");
            }
         return Ok(result);
        }
      
    }
}
