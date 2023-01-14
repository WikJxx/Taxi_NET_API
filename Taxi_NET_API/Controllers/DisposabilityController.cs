using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Taxi_NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisposabilityController : ControllerBase
    {
        private readonly IDisposabilityService _disposabilityService;
        public DisposabilityController(IDisposabilityService disposabilityService)
        {
            _disposabilityService = disposabilityService;
        }
         [HttpGet("{id}")]
        public async Task<ActionResult<List<TaxiDriver>>> GetDisposability(int id)
        {
          
            var result = await _disposabilityService.GetDisposability(id);

            if (result == null)
            {
                return NotFound("Disposability not found :c");
            }

            return Ok(result);
        }
    }
}
