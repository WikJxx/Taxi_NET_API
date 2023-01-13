namespace Taxi_NET_API.Services.TripService
{
    public interface ITripService
    {
        Task<List<Trip>?> GetTrip();
        Task<Trip?> GetTrip(int id);
        Task<List<Trip>?> PutTrip(int id, Trip trip);
        Task<List<Trip>?> PostTrip(Trip trip);
        Task<List<Trip>?> DeleteTrip(int id);

    }
}