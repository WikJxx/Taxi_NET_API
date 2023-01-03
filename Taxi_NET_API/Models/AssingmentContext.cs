using Microsoft.EntityFrameworkCore;
namespace Taxi_NET_API.Models;
public class AssingmentContext : DbContext
{
     public AssingmentContext(DbContextOptions<AssingmentContext>options) : base (options)
    {

    }
    public DbSet<Assingment> Assingments {get; set;} =null!;
}