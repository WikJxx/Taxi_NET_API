global using Microsoft.EntityFrameworkCore;
global using Taxi_NET_API.Data;
global using Taxi_NET_API.Models;
global using Taxi_NET_API.Services.CombustionTaxiService;
global using Taxi_NET_API.Services.ElectricTaxiService;
global using Taxi_NET_API.Services.TaxiAssignmentService;
global using Taxi_NET_API.Services.TaxiDriverService;
global using Taxi_NET_API.Services.TripService;
global using Taxi_NET_API.Services.DisposabilityService;
global using Taxi_NET_API.Services.DriverChoiceService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICombustionTaxiService, CombustionTaxiService>();
builder.Services.AddScoped<IElectricTaxiService, ElectricTaxiService>();
builder.Services.AddScoped<ITaxiAssignmentService, TaxiAssingmentService>();
builder.Services.AddScoped<ITaxiDriverService, TaxiDriverService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IDisposabilityService, DisposabilityService>();
builder.Services.AddScoped<IDriverChoiceService, DriverChoiceService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
