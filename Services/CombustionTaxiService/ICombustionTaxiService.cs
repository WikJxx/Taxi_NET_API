namespace Taxi_NET_API.Services.CombustionTaxiService
{
    public interface ICombustionTaxiService
    {
        Task<List<CombustionTaxi>?> GetCombustionTaxis();
        Task<CombustionTaxi?> GetCombustionTaxi(int id);
        Task<List<CombustionTaxi>?> PutCombustionTaxi(int id, CombustionTaxi combustionTaxi);
        Task<List<CombustionTaxi>?> PostCombustionTaxi(CombustionTaxi combustionTaxi);
        Task<List<CombustionTaxi>?> DeleteCombustionTaxi(int id);

    }
}
