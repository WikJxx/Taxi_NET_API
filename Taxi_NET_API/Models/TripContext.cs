using Microsoft.EntityFrameworkCore;
namespace Taxi_NET_API.Models;
public class TripContext : DbContext
{
     public TripContext(DbContextOptions<TripContext>options) : base (options)
    {

    }
    public DbSet<Trip> Trips {get; set;} =null!;
}