using Taxi_NET_API.Models;

namespace Taxi_NET_API.Services.TaxiAssingmentService
{
    public class TaxiAssingmentService : ITaxiAssingmentService
    {
        private readonly DataContext _context;
        public TaxiAssingmentService(DataContext context)
        {
                _context = context;
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