namespace Taxi_NET_API.Services.TripService
{
    public class TripService : ITripService
    {
        private readonly DataContext _context;
        public TripService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Trip>?> GetTrips()
        {
            var trips = await _context.Trips.ToListAsync();

            if (trips == null)
            {
                return null;
            }

            return trips;

        }

        public async Task<Trip?> GetTrip(int id)
        {
            var trip = await _context.Trips.FindAsync(id);

            if (trip == null)
            {
                return null;
            }

            return trip;
        }

        public async Task<List<Trip>?> PutTrip(int id, Trip request)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return null;
            }
            trip.XStartCoordinates = request.XStartCoordinates;
            trip.XFinishCoordinates = request.XFinishCoordinates;
            trip.YStartCoordinates = request.YStartCoordinates;
            trip.YFinishCoordinates = request.YFinishCoordinates;

            await _context.SaveChangesAsync();
            return await _context.Trips.ToListAsync();
        }

        public async Task<List<Trip>?> PostTrip(Trip request)
        {
            _context.Trips.Add(request);
            await _context.SaveChangesAsync();
            return await _context.Trips.ToListAsync();
        }


        public async Task<List<Trip>?> DeleteTrip(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return null;
            }
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();

            return await _context.Trips.ToListAsync();

        }

    }
}