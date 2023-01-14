global using Microsoft.EntityFrameworkCore;
global using Taxi_NET_API.Data;
global using Taxi_NET_API.Models;
global using Taxi_NET_API.Services.CombustionTaxiService;
global using Taxi_NET_API.Services.ElectricTaxiService;
global using Taxi_NET_API.Services.TaxiAssingmentService;
global using Taxi_NET_API.Services.TaxiDriverService;
global using Taxi_NET_API.Services.TripService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICombustionTaxiService, CombustionTaxiService>();
builder.Services.AddScoped<IElectricTaxiService, ElectricTaxiService>();
builder.Services.AddScoped<ITaxiAssingmentService, TaxiAssingmentService>();
builder.Services.AddScoped<ITaxiDriverService, TaxiDriverService>();
builder.Services.AddScoped<ITripService, TripService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
