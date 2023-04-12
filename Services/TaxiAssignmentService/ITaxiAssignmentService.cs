namespace Taxi_NET_API.Services.TaxiAssignmentService
{
    public interface ITaxiAssignmentService
    {
        Task<List<TaxiAssignment>?> GetTaxiAssignments();
        Task<TaxiAssignment?> GetTaxiAssignment(int id);
        Task<List<TaxiAssignment>?> PutTaxiAssignment(int id, TaxiAssignment taxiAssignment);
        Task<List<TaxiAssignment>?> PostTaxiAssignment(TaxiAssignment taxiAssignment);
        Task<List<TaxiAssignment>?> DeleteTaxiAssignment(int id);

    }
}