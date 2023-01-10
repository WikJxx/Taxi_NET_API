using Microsoft.EntityFrameworkCore;
using Taxi_NET_API.Models;

namespace Taxi_NET_API.Data; 

public class DataContext :DbContext
{
    public DataContext(DbContextOptions<DataContext>options):base (options)
    {

    }
    public DbSet<TaxiDriver> TaxiDrivers {get; set;}=null!;
    

}