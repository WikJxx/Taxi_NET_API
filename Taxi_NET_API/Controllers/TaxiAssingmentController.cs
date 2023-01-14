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
    public class TaxiAssingmentController : ControllerBase
    {
        private readonly ITaxiAssingmentService _taxiAssingmentService;
        

        public TaxiAssingmentController(ITaxiAssingmentService taxiAssingmentService)
        {
            _taxiAssingmentService = taxiAssingmentService;
        }

        
        [HttpGet]
         public async Task<ActionResult<List<TaxiAssingment>>> GetTaxiAssingment()
        {
          var result = await _taxiAssingmentService.GetTaxiAssingment();
          if (result == null)
          {
            return  NotFound("Taxi Assingments not found :c");
          }
          return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaxiAssingment>> GetTaxiAssingment(int id)
        {
          
            var result = await _taxiAssingmentService.GetTaxiAssingment(id);

            if (result == null)
            {
                return NotFound("Assingment with that id not found :c");
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TaxiAssingment>>> PutTaxiAssingment(int id, TaxiAssingment taxiAssingment)
        {
           var result = await _taxiAssingmentService.PutTaxiAssingment(id, taxiAssingment);
           if (result == null)
            {
                return NotFound("Assingment with that id not found :c");
            }

            return Ok(result);
        }

        [HttpPost]
         public async Task<ActionResult<List<TaxiAssingment>>> PostTaxiAssingment(TaxiAssingment taxiAssingment)
        {
         var result = await _taxiAssingmentService.PostTaxiAssingment(taxiAssingment); 
         if (result == null)
         {
            NotFound("Taxi assingment couldn't be created.");
            
         }
         return Ok(result);
        }

     
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TaxiAssingment>>> DeleteTaxiAssingment(int id)
        {
           var result = await _taxiAssingmentService.DeleteTaxiAssingment(id);
            if (result == null)
            {
                return NotFound("Taxi assingment with that id not found :c ");
            }
            return Ok(result);

        }
    }
}
