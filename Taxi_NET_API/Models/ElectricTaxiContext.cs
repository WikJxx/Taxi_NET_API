using Microsoft.EntityFrameworkCore;
namespace Taxi_NET_API.Models;
public class ElectricTaxiContext : DbContext
{
    public ElectricTaxiContext(DbContextOptions<ElectricTaxiContext>options) : base (options)
    {

    }
    public DbSet<ElectricTaxi> ElectricTaxis {get; set;} =null!;
}