namespace Taxi_NET_API.Services.ElectricTaxiService
{
    public class ElectricTaxiService : IElectricTaxiService
    {
        private readonly DataContext _context;
        public ElectricTaxiService(DataContext context)
        {
                _context = context;
        }
        
         public async Task<List<ElectricTaxi>?> GetElectricTaxis()
        {
          var electricTaxis = await _context.ElectricTaxis.ToListAsync();

            if (electricTaxis == null)
            {
                return null;
            }

          return electricTaxis;
          
        }
        
        public async Task<ElectricTaxi?> GetElectricTaxi(int id)
        {
          var electricTaxi = await _context.ElectricTaxis.FindAsync(id);
          
            if (electricTaxi == null)
            {
                return null;
            }

          return electricTaxi;
        }

        public async Task<List<ElectricTaxi>?> PutElectricTaxi(int id, ElectricTaxi request)
        {
            var electricTaxi = await _context.ElectricTaxis.FindAsync(id);
            if (electricTaxi == null)
            {
                return null;
            }
            electricTaxi.CarBrand = request.CarBrand;
            electricTaxi.CarDoor = request.CarDoor;
            electricTaxi.Colour = request.Colour;
            electricTaxi.IsGearBox = request.IsGearBox;
            electricTaxi.batteryCapacity = request.batteryCapacity;
            electricTaxi.ProductionYear = request.ProductionYear;
            electricTaxi.TravelRange = request.TravelRange;

            await _context.SaveChangesAsync();
            return await _context.ElectricTaxis.ToListAsync();
        }

        public async Task<List<ElectricTaxi>?> PostElectricTaxi(ElectricTaxi request)
        {
          _context.ElectricTaxis.Add(request);
          await _context.SaveChangesAsync();
          return await _context.ElectricTaxis.ToListAsync();
        }

        
        public async Task<List<ElectricTaxi>?> DeleteElectricTaxi(int id)
        { 
            var electricTaxi = await _context.ElectricTaxis.FindAsync(id);
             if (electricTaxi == null)
            {
                return null;
            }
            _context.ElectricTaxis.Remove(electricTaxi);
            await _context.SaveChangesAsync();

            return await _context.ElectricTaxis.ToListAsync();

        }
        
    }
}