Technologies: C#, .NET, EntityFramework

Goal of this API is to manage the group of drivers and the fleet of cars owned by a taxi company. 

Functionalities of the API:
- Adding drivers, cars of various types and trips
- Assigning a car to a driver, checking whether his license allows it (drivers with an automatic-only license cannot drive a car with a manual transmission). 
- Ordering trips by entering the starting coordinates and the coordinates of the destination point. 
- Checking which driver is able to serve the order
- Assigning drivers to the trips. The driver can be chosen when his range and location allow it. Once the order is executed, the driver's coordinates are changed to the destination point.



How to use:
Download SQL Server from https://www.microsoft.com/en-us/sql-server/sql-server-downloads
Download Server Management Studio from https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
Clone the repository
While in the Taxi_NET_API directory, run the "dotnet ef database update" command
While in the Taxi_NET_API directory, run the "dotnet run" command
The API should run after completing these steps. To view the Swagger documentation enter in your browser the URL returned in the response to the "dotnet run" command.

