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
        public DbSet<TaxiAssignment> TaxiAssignments => Set<TaxiAssignment>();
        public DbSet<DriverChoice> DriverChoices => Set<DriverChoice>();
    }
}