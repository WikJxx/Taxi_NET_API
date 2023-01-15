namespace Taxi_NET_API.Services.DriverChoiceService
{
    public class DriverChoiceService : IDriverChoiceService
    {
       private readonly ITaxiDriverService _taxiDriverService;
       private readonly IDisposabilityService _disposabilityService;
       private readonly ITripService _tripService;
       private readonly DataContext _context;
        public DriverChoiceService(ITaxiDriverService taxiDriverService, IDisposabilityService disposabilityService, ITripService tripService, DataContext context)
        {
            _taxiDriverService = taxiDriverService;
            _disposabilityService = disposabilityService;
            _tripService = tripService;
            _context = context;
        }
        
         public async Task<List<DriverChoice>?> GetDriverChoices()
        {
          var driverChoices = await _context.DriverChoices.ToListAsync();

            if (driverChoices == null)
            {
                return null;
            }

          return driverChoices;
          
        }
        
        public async Task<DriverChoice?> GetDriverChoice(int id)
        {
          var driverChoice = await _context.DriverChoices.FindAsync(id);
          
            if (driverChoice == null)
            {
                return null;
            }

          return driverChoice;
        }

        public async Task<TaxiDriver?> ExecuteDriverChoice(DriverChoice driverChoice)
        {
          var taxiDriver = await _taxiDriverService.GetTaxiDriver(driverChoice.TaxiDriverID);
          var disposableDrivers = await _disposabilityService.GetDisposability(driverChoice.TripID);
          var trip = await _tripService.GetTrip(driverChoice.TripID);
            if (taxiDriver == null || disposableDrivers == null || trip == null)
            {
                return null;
            }
            var taxiDriverIsDisposable = false;
            foreach (var driver in disposableDrivers)
            {
                if (driver.TaxiDriverID == taxiDriver.TaxiDriverID)
                {
                    taxiDriverIsDisposable = true;
                }

            }
            if (!taxiDriverIsDisposable)
            {
                return null;
            }
            taxiDriver.XCoordinates = trip.XFinishCoordinates;
            taxiDriver.YCoordinates = trip.YFinishCoordinates;
            await _taxiDriverService.PutTaxiDriver(taxiDriver.TaxiDriverID,taxiDriver);
            _context.DriverChoices.Add(driverChoice);
            await _context.SaveChangesAsync();

          return taxiDriver;
        }

    }
}