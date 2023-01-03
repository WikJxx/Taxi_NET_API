using Microsoft.EntityFrameworkCore;
namespace Taxi_NET_API.Models; 

public class TaxiDriverContext :DbContext
{
    public TaxiDriverContext(DbContextOptions<TaxiDriverContext>options):base (options)
    {

    }
    public DbSet<TaxiDriver> TaxiDrivers {get; set;} = null!;

}