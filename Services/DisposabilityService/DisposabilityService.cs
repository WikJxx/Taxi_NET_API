namespace Taxi_NET_API.Services.DisposabilityService
{
    public class DisposabilityService : IDisposabilityService
    {
    
        private readonly ITripService _tripService;
        private readonly ITaxiDriverService _taxiDriverService;
        private readonly ITaxiAssignmentService _taxiAssignmentService;
        private readonly ICombustionTaxiService _combustionTaxiService;
        private readonly IElectricTaxiService _electricTaxiService;
        public DisposabilityService(ITripService tripService, ITaxiDriverService taxiDriverService, ITaxiAssignmentService taxiAssignmentService, ICombustionTaxiService combustionTaxiService, IElectricTaxiService electricTaxiService)
        {
                _tripService = tripService;
                _taxiDriverService = taxiDriverService;
                _taxiAssignmentService = taxiAssignmentService;
                _combustionTaxiService = combustionTaxiService;
                _electricTaxiService = electricTaxiService;
        }

        public async Task<List<TaxiDriver>?> GetDisposability(int tripID)
        {
            List<TaxiDriver> disposability = new List<TaxiDriver>();
            var trip = await _tripService.GetTrip(tripID);
            var taxiAssignments = await _taxiAssignmentService.GetTaxiAssignments();
            if (taxiAssignments == null || trip == null)
            {
                return null;
            }
            foreach(var assignment in taxiAssignments)
            { 
              Taxi? taxi;  
                if (assignment.IsElectric)
                {
                   taxi = await _electricTaxiService.GetElectricTaxi(assignment.TaxiID);
                }
                else
                {
                    taxi = await _combustionTaxiService.GetCombustionTaxi(assignment.TaxiID);
                }

                var taxiDriver = await _taxiDriverService.GetTaxiDriver(assignment.TaxiDriverID);

                if (taxiDriver==null || taxi == null)
                {
                    return null;
                }

                var distanceToPassenger = Math.Sqrt(Math.Pow(taxiDriver.XCoordinates-trip.XStartCoordinates,2)+ Math.Pow(taxiDriver.YCoordinates-trip.YStartCoordinates,2));
                var tripDistance = Math.Sqrt(Math.Pow(trip.XStartCoordinates-trip.XFinishCoordinates,2)+ Math.Pow(trip.YStartCoordinates-trip.YFinishCoordinates,2));
                if (taxi.TravelRange >= distanceToPassenger+tripDistance)
                {
                    disposability.Add(taxiDriver);

                }
            }
          return disposability;
        }


    }
}