namespace Taxi_NET_API.Models;
public class TaxiDriver
{
    public int TaxiDriverID {get; set;}
    public string? Name {get; set;}
    public string? Surname {get; set;}
    public int Age {get; set;}
    public bool IsManualLicence {get; set;}
    public int XCoordinates {get; set;} 
    public int YCoordinates {get; set;} 

}