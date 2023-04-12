namespace Taxi_NET_API.Services.DriverChoiceService
{
    public interface IDriverChoiceService
    {
        Task<List<DriverChoice>?> GetDriverChoices();
        Task<DriverChoice?> GetDriverChoice(int id);
        Task<TaxiDriver?> ExecuteDriverChoice(DriverChoice driverChoice);
        

    }
}