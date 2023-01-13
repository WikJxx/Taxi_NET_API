global using Microsoft.EntityFrameworkCore;
global using Taxi_NET_API.Data;
global using Taxi_NET_API.Models;
global using Taxi_NET_API.Services.CombustionTaxiService;
global using Taxi_NET_API.Services.ElectricTaxiService;
global using Taxi_NET_API.Services.TaxiAssingmentService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICombustionTaxiService, CombustionTaxiService>();
builder.Services.AddScoped<IElectricTaxiService, ElectricTaxiService>();

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
