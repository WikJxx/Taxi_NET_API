namespace Taxi_NET_API.Services.TaxiAssingmentService
{
    public interface ITaxiAssingmentService
    {
        Task<List<TaxiAssingment>?> GetTaxiAssingment();
        Task<TaxiAssingment?> GetTaxiAssingment(int id);
        Task<List<TaxiAssingment>?> PutTaxiAssingment(int id, TaxiAssingment taxiAssingment);
        Task<List<TaxiAssingment>?> PostTaxiAssingment(TaxiAssingment taxiAssingment);
        Task<List<TaxiAssingment>?> DeleteTaxiAssingment(int id);

    }
}