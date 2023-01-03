namespace Taxi_NET_API.Models;
public class ElectricTaxi
{
    public int electricTaxiID {get; set;}
    public string? CarBrand {get; set;}
    public int CarDoor {get; set;}
    public string? Colour {get; set;}
    public bool IsGearBox {get; set;}
    public int ProductionYear {get; set;}
    public int TravelRange {get; set;}
    public int batteryCapacity {get; set;}
}