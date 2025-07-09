using MajesticRoutePlanner.Domain.Entities;
using MajesticRoutePlanner.Domain.Enums;
using MajesticRoutePlanner.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MajesticRoutePlanner.Infrastructure.Data;

public class VehicleRepository : IVehicleRepository
{
    private readonly ILogger<VehicleRepository> _logger;
    private readonly IOptionsSnapshot<List<VehicleConfig>> _options;

    public VehicleRepository(IOptionsSnapshot<List<VehicleConfig>> options, ILogger<VehicleRepository> logger)
    {
        _options = options;
        _logger = logger;
    }

    public IEnumerable<Vehicle> GetAvailableVehicles(WeatherType weather)
    {
        var allVehicles = _options.Value.Select(v =>
            new Vehicle(v.Name, v.MaxSpeed, v.CraterTime, v.CanUseInRain)).ToList();

        _logger.LogDebug("📦 Loaded vehicle configs: {@Vehicles}", allVehicles);

        var filtered = allVehicles
            .Where(v => weather != WeatherType.Rainy || v.CanUseInRain)
            .ToList();

        _logger.LogInformation("✅ Available vehicles for {Weather}: {@Filtered}", weather, filtered);
        return filtered;
    }
}