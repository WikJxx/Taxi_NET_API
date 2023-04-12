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
      var chosenTaxiDriver = await _taxiDriverService.GetTaxiDriver(driverChoice.TaxiDriverID);
      var disposableDrivers = await _disposabilityService.GetDisposability(driverChoice.TripID);        
      var trip = await _tripService.GetTrip(driverChoice.TripID);
      var taxiDrivers = await _taxiDriverService.GetTaxiDrivers();
      if (chosenTaxiDriver == null || disposableDrivers == null || trip == null ||taxiDrivers == null)
      {
        return null;        
        }
      var taxiDriverIsDisposable = false;
      foreach (var driver in disposableDrivers)
      {
        if (driver.TaxiDriverID == chosenTaxiDriver.TaxiDriverID)
        {
          taxiDriverIsDisposable = true;
        }

      }
      if (!taxiDriverIsDisposable)
      {
        return null;
      }
      chosenTaxiDriver.XCoordinates = trip.XFinishCoordinates;
      chosenTaxiDriver.YCoordinates = trip.YFinishCoordinates;
      await _taxiDriverService.PutTaxiDriver(chosenTaxiDriver.TaxiDriverID,chosenTaxiDriver);
      Random rnd = new Random();
      foreach(var driver in taxiDrivers)
      {
        if (driver.TaxiDriverID != chosenTaxiDriver.TaxiDriverID)
        {
          var coordinatesChange = rnd.NextDouble()*rnd.Next(-5,5);
          driver.XCoordinates += coordinatesChange;
          coordinatesChange = rnd.NextDouble()*rnd.Next(-5,5);
          driver.YCoordinates += coordinatesChange;
          await _taxiDriverService.PutTaxiDriver(driver.TaxiDriverID, driver); 
        }
              
      }
      _context.DriverChoices.Add(driverChoice);
      await _context.SaveChangesAsync();

      return chosenTaxiDriver;
    }

  }
}