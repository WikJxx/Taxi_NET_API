global using Microsoft.EntityFrameworkCore;
global using Taxi_NET_API.Data;
using Taxi_NET_API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// builder.Services.AddDbContext<ElectricTaxiContext>(opt => opt.UseInMemoryDatabase("ElectricTaxiList"));
// builder.Services.AddDbContext<CombustionTaxiContext>(opt => opt.UseInMemoryDatabase("CombustionTaxiList"));
// builder.Services.AddDbContext<TaxiDriverContext>(opt => opt.UseInMemoryDatabase("TaxiDriversList"));
// builder.Services.AddDbContext<TripContext>(opt => opt.UseInMemoryDatabase("TripList"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.MapGet("/electrictaxis", async (DataContext db)=> await db.ElectricTaxis.ToListAsync());
app.MapPost("/electrictaxis",async (ElectricTaxi electrictaxi,DataContext db)=> 
{
    db.ElectricTaxis.Add(electrictaxi);
    await db.SaveChangesAsync();
    return Results.Created($"/electricTaxis/{electrictaxi.electricTaxiID}",electrictaxi);
});

app.Run();
