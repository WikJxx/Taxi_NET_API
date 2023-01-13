namespace Taxi_NET_API.Services.TaxiDriverService
{
    public interface ITaxiDriverService
    {
        Task<List<TaxiDriver>?> GetTaxiDriver();
        Task<TaxiDriver?> GetTaxiDriver(int id);
        Task<List<TaxiDriver>?> PutTaxiDriver(int id, TaxiDriver taxiDriver);
        Task<List<TaxiDriver>?> PostTaxiDriver(TaxiDriver taxiDriver);
        Task<List<TaxiDriver>?> DeleteTaxiDriver(int id);

    }
}