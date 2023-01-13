namespace Taxi_NET_API.Services.CombustionTaxiService
{
    public class CombustionTaxiService : ICombustionTaxiService
    {
        private readonly DataContext _context;
        public CombustionTaxiService(DataContext context)
        {
                _context = context;
        }
        
         public async Task<List<CombustionTaxi>?> GetCombustionTaxis()
        {
          var combustionTaxis = await _context.CombustionTaxis.ToListAsync();

            if (combustionTaxis == null)
            {
                return null;
            }

          return combustionTaxis;
          
        }
        
        public async Task<CombustionTaxi?> GetCombustionTaxi(int id)
        {
          var combustionTaxi = await _context.CombustionTaxis.FindAsync(id);
          
            if (combustionTaxi == null)
            {
                return null;
            }

          return combustionTaxi;
        }

        public async Task<List<CombustionTaxi>?> PutCombustionTaxi(int id, CombustionTaxi request)
        {
            var combustionTaxi = await _context.CombustionTaxis.FindAsync(id);
            if (combustionTaxi == null)
            {
                return null;
            }
            combustionTaxi.CarBrand = request.CarBrand;
            combustionTaxi.CarDoor = request.CarDoor;
            combustionTaxi.Colour = request.Colour;
            combustionTaxi.IsGearBox = request.IsGearBox;
            combustionTaxi.FuelType = request.FuelType;
            combustionTaxi.ProductionYear = request.ProductionYear;
            combustionTaxi.TravelRange = request.TravelRange;

            await _context.SaveChangesAsync();
            return await _context.CombustionTaxis.ToListAsync();
        }

        public async Task<List<CombustionTaxi>?> PostCombustionTaxi(CombustionTaxi request)
        {
          _context.CombustionTaxis.Add(request);
          await _context.SaveChangesAsync();
          return await _context.CombustionTaxis.ToListAsync();
        }

        
        public async Task<List<CombustionTaxi>?> DeleteCombustionTaxi(int id)
        { 
            var combustionTaxi = await _context.CombustionTaxis.FindAsync(id);
             if (combustionTaxi == null)
            {
                return null;
            }
            _context.CombustionTaxis.Remove(combustionTaxi);
            await _context.SaveChangesAsync();

            return await _context.CombustionTaxis.ToListAsync();

        }
        
    }
}