using Taxi_NET_API.Models;


namespace Taxi_NET_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }


        public DbSet<CombustionTaxi> CombustionTaxis => Set<CombustionTaxi>();
        public DbSet<ElectricTaxi> ElectricTaxis => Set<ElectricTaxi>();
        public DbSet<TaxiDriver> TaxiDrivers => Set<TaxiDriver>();
        public DbSet<Trip> Trips => Set<Trip>();
        public DbSet<TaxiAssingment> TaxiAssingments => Set<TaxiAssingment>();
    }
}