
namespace Taxi_NET_API.Services.TaxiAssingmentService
{
    public class TaxiAssingmentService : ITaxiAssingmentService
    {
        private readonly DataContext _context;
        private readonly ICombustionTaxiService _combustionTaxiService;
        private readonly IElectricTaxiService _electricTaxiService;
        private readonly ITaxiDriverService _taxiDriverService;
        
        public TaxiAssingmentService(DataContext context,ICombustionTaxiService combustionTaxiService, IElectricTaxiService electricTaxiService,ITaxiDriverService taxiDriverService)
        {
                _context = context;
                _combustionTaxiService = combustionTaxiService;
                _electricTaxiService = electricTaxiService;
                _taxiDriverService = taxiDriverService;
        }
        
         public async Task<List<TaxiAssingment>?> GetTaxiAssingment()
        {
          var taxiAssingments = await _context.TaxiAssingments.ToListAsync();

            if (taxiAssingments == null)
            {
                return null;
            }

          return taxiAssingments;
          
        }
        
        public async Task<TaxiAssingment?> GetTaxiAssingment(int id)
        {
          var taxiAssingment = await _context.TaxiAssingments.FindAsync(id);
          
            if (taxiAssingment == null)
            {
                return null;
            }

          return taxiAssingment;
        }

        public async Task<List<TaxiAssingment>?> PutTaxiAssingment(int id, TaxiAssingment request)
        {
            var taxiAssingment = await _context.TaxiAssingments.FindAsync(id);
            if (taxiAssingment == null)
            {
                return null;
            }
            taxiAssingment.TaxiDriverID = request.TaxiDriverID;
            taxiAssingment.TaxiID = request.TaxiID;
            taxiAssingment.IsElectric = request.IsElectric;

            await _context.SaveChangesAsync();
            return await _context.TaxiAssingments.ToListAsync();
        }

        public async Task<List<TaxiAssingment>?> PostTaxiAssingment(TaxiAssingment request)
        {
          var taxiIsManual = false;
          var driverIsManual = false;
          var assingments = await _context.TaxiAssingments.ToListAsync();

          if (request.IsElectric)
          {
            var taxis = await _electricTaxiService.GetElectricTaxis();
             if (taxis == null)
            {
                return null;
            }
            var taxiExists = false;
            foreach (var taxi in taxis)
            {
              if (taxi.electricTaxiID == request.TaxiID)
              {
                taxiExists = true;
                taxiIsManual = taxi.IsGearBox;
              } 
            }
            if (!taxiExists)
            {
              return null;
            } 
          }
          else 
          {
             var taxis = await _combustionTaxiService.GetCombustionTaxis();
             if (taxis == null)
            {
                return null;
            }
            var taxiExists = false;
            foreach (var taxi in taxis)
            {
              if (taxi.CombustionTaxiID == request.TaxiID)
              {
                taxiExists = true;
                taxiIsManual = taxi.IsGearBox;
              } 
            }
            if (!taxiExists)
            {
              return null;
            } 

          }
          var drivers = await _taxiDriverService.GetTaxiDrivers();
           if (drivers == null)
            {
                return null;
            }
            var driverExists = false;
            foreach (var driver in drivers)
            {
              if (driver.TaxiDriverID == request.TaxiDriverID)
              {
                driverExists = true;
                driverIsManual = driver.IsManualLicence;
              } 
            }
            if (!driverExists)
            {
              return null;
            } 
            if (!driverIsManual && taxiIsManual)
            {
              return null;
            }
            foreach(var assingment in assingments)
            {
              if (assingment.TaxiDriverID == request.TaxiDriverID || (assingment.TaxiID == request.TaxiID && assingment.IsElectric == request.IsElectric))
              {
                return null;
              }
            }
          _context.TaxiAssingments.Add(request);
          await _context.SaveChangesAsync();
          return await _context.TaxiAssingments.ToListAsync();
        }

        
        public async Task<List<TaxiAssingment>?> DeleteTaxiAssingment(int id)
        { 
            var taxiAssingment = await _context.TaxiAssingments.FindAsync(id);
             if (taxiAssingment == null)
            {
                return null;
            }
            _context.TaxiAssingments.Remove(taxiAssingment);
            await _context.SaveChangesAsync();

            return await _context.TaxiAssingments.ToListAsync();

        }

        
    
    }
}