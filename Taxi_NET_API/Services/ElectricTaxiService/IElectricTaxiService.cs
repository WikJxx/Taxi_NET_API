namespace Taxi_NET_API.Services.ElectricTaxiService
{
    public interface IElectricTaxiService
    {
        Task<List<ElectricTaxi>?> GetElectricTaxis();
        Task<ElectricTaxi?> GetElectricTaxi(int id);
        Task<List<ElectricTaxi>?> PutElectricTaxi(int id, ElectricTaxi electricTaxi);
        Task<List<ElectricTaxi>?> PostElectricTaxi(ElectricTaxi electricTaxi);
        Task<List<ElectricTaxi>?> DeleteElectricTaxi(int id);

    }
}