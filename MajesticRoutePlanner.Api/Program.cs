using MajesticRoutePlanner.Application.Services;
using MajesticRoutePlanner.Domain.Interfaces;
using MajesticRoutePlanner.Infrastructure.Data;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<List<VehicleConfig>>(builder.Configuration.GetSection("Vehicles"));
builder.Services.Configure<List<OrbitConfig>>(builder.Configuration.GetSection("Orbits"));

builder.Services.AddSingleton<RouteEvaluator>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IOrbitRepository, OrbitRepository>();

var app = builder.Build();

app.UseRouting();

app.UseHttpMetrics();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Majestic API V1");
});

app.MapMetrics();
app.MapControllers();

app.Run();

public partial class Program { }
