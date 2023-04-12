namespace Taxi_NET_API.Services.ElectricTaxiService
{
    public interface IDisposabilityService
    {
        Task<List<TaxiDriver>?> GetDisposability(int id);
    }
}