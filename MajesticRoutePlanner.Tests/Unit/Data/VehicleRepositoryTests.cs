using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Castle.Core.Logging;
using MajesticRoutePlanner.Domain.Enums;
using MajesticRoutePlanner.Infrastructure.Data;
using Moq;

namespace MajesticRoutePlanner.Tests.Unit.Data;

public class VehicleRepositoryTests
{
    [Fact]
    public void Filters_Out_Rain_Unsafe_Vehicles_When_Weather_Is_Rainy()
    {
        var config = new List<VehicleConfig>
        {
            new() { Name = "Bike", MaxSpeed = 10, CraterTime = 2, CanUseInRain = true },
            new() { Name = "Car", MaxSpeed = 20, CraterTime = 3, CanUseInRain = false }
        };

        var snapshot = new Mock<IOptionsSnapshot<List<VehicleConfig>>>();
        snapshot.Setup(o => o.Value).Returns(config);

        var repo = new VehicleRepository(snapshot.Object, new LoggerFactory().CreateLogger<VehicleRepository>());

        var result = repo.GetAvailableVehicles(WeatherType.Rainy).ToList();

        Assert.Single(result);
        Assert.Equal("Bike", result.First().Name);
    }

    [Fact]
    public void Includes_AllVehicles_IfWeatherIsNotRainy()
    {
        var config = new List<VehicleConfig>
        {
            new() { Name = "Bike", MaxSpeed = 10, CraterTime = 2, CanUseInRain = true },
            new() { Name = "Car", MaxSpeed = 20, CraterTime = 3, CanUseInRain = false }
        };

        var snapshot = new Mock<IOptionsSnapshot<List<VehicleConfig>>>();
        snapshot.Setup(o => o.Value).Returns(config);

        var repo = new VehicleRepository(snapshot.Object, new LoggerFactory().CreateLogger<VehicleRepository>());
        var result = repo.GetAvailableVehicles(WeatherType.Sunny).Select(v => v.Name).ToList();

        Assert.Equal(2, result.Count);
        Assert.Contains("Car", result);
    }
}