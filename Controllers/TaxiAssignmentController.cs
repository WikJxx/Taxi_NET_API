using Microsoft.AspNetCore.Mvc;

namespace Taxi_NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiAssignmentController : ControllerBase
    {
        private readonly ITaxiAssignmentService _taxiAssignmentService;
        

        public TaxiAssignmentController(ITaxiAssignmentService taxiAssingmentService)
        {
            _taxiAssignmentService = taxiAssingmentService;
        }

        
        [HttpGet]
         public async Task<ActionResult<List<TaxiAssignment>>> GetTaxiAssignment()
        {
          var result = await _taxiAssignmentService.GetTaxiAssignments();
          if (result == null)
          {
            return  NotFound("Taxi Assignments not found :c");
          }
          return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaxiAssignment>> GetTaxiAssignment(int id)
        {
          
            var result = await _taxiAssignmentService.GetTaxiAssignment(id);

            if (result == null)
            {
                return NotFound("Assignment with that id not found :c");
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TaxiAssignment>>> PutTaxiAssignment(int id, TaxiAssignment taxiAssingment)
        {
           var result = await _taxiAssignmentService.PutTaxiAssignment(id, taxiAssingment);
           if (result == null)
            {
                return NotFound("Assignment with that id not found :c");
            }

            return Ok(result);
        }

        [HttpPost]
         public async Task<ActionResult<List<TaxiAssignment>>> PostTaxiAssignment(TaxiAssignment taxiAssignment)
        {
         var result = await _taxiAssignmentService.PostTaxiAssignment(taxiAssignment); 
         if (result == null)
         {
            NotFound("Taxi assignment couldn't be created.");
            
         }
         return Ok(result);
        }

     
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TaxiAssignment>>> DeleteTaxiAssignment(int id)
        {
           var result = await _taxiAssignmentService.DeleteTaxiAssignment(id);
            if (result == null)
            {
                return NotFound("Taxi assignment with that id not found :c ");
            }
            return Ok(result);

        }
    }
}
