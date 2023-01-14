namespace Taxi_NET_API.Services.TaxiDriverService
{
    public class TaxiDriverService : ITaxiDriverService
    {
        private readonly DataContext _context;
        public TaxiDriverService(DataContext context)
        {
                _context = context;
        }
        
         public async Task<List<TaxiDriver>?> GetTaxiDrivers()
        {
          var taxiDrivers = await _context.TaxiDrivers.ToListAsync();

            if (taxiDrivers == null)
            {
                return null;
            }

          return taxiDrivers;
          
        }
        
        public async Task<TaxiDriver?> GetTaxiDriver(int id)
        {
          var taxiDriver = await _context.TaxiDrivers.FindAsync(id);
          
            if (taxiDriver == null)
            {
                return null;
            }

          return taxiDriver;
        }

        public async Task<List<TaxiDriver>?> PutTaxiDriver(int id, TaxiDriver request)
        {
            var taxiDriver = await _context.TaxiDrivers.FindAsync(id);
            if (taxiDriver == null)
            {
                return null;
            }
            taxiDriver.Name = request.Name;
            taxiDriver.Surname = request.Surname;
            taxiDriver.Age = request.Age;
            taxiDriver.IsManualLicence = request.IsManualLicence;
            taxiDriver.XCoordinates = request.XCoordinates;
            taxiDriver.YCoordinates = request.YCoordinates;

            await _context.SaveChangesAsync();
            return await _context.TaxiDrivers.ToListAsync();
        }

        public async Task<List<TaxiDriver>?> PostTaxiDriver(TaxiDriver request)
        {
          _context.TaxiDrivers.Add(request);
          await _context.SaveChangesAsync();
          return await _context.TaxiDrivers.ToListAsync();
        }

        
        public async Task<List<TaxiDriver>?> DeleteTaxiDriver(int id)
        { 
            var taxiDriver = await _context.TaxiDrivers.FindAsync(id);
             if (taxiDriver == null)
            {
                return null;
            }
            _context.TaxiDrivers.Remove(taxiDriver);
            await _context.SaveChangesAsync();

            return await _context.TaxiDrivers.ToListAsync();

        }
        
    }
}