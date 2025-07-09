using MajesticRoutePlanner.Domain.Enums;
using MajesticRoutePlanner.Application.Services;
using MajesticRoutePlanner.Domain.Entities;

namespace MajesticRoutePlanner.Tests.Unit.Services;

public class RouteEvaluatorTests
{
    [Fact]
    public void Returns_TukTuk_On_Orbit1_For_Sunny_Condition()
    {
        var evaluator = new RouteEvaluator();
        var vehicles = new List<Vehicle>
        {
            new("Bike", 10, 2, true),
            new("TukTuk", 12, 1, true),
            new("Car", 20, 3, false)
        };
        var orbits = new List<Orbit>
        {
            new("Orbit1", 18, 20, 12),
            new("Orbit2", 20, 10, 14)
        };

        var result = evaluator.FindFastestRoute(vehicles, orbits, WeatherType.Sunny);

        Assert.Equal("TukTuk", result.Vehicle);
        Assert.Equal("Orbit1", result.Orbit);
        Assert.Equal(108, result.TravelTime);
    }

    [Fact]
    public void Returns_Car_On_Orbit2_For_Windy_Condition()
    {
        var evaluator = new RouteEvaluator();
        var vehicles = new List<Vehicle>
        {
            new("Bike", 10, 2, true),
            new("TukTuk", 12, 1, true),
            new("Car", 20, 3, false)
        };
        var orbits = new List<Orbit>
        {
            new("Orbit1", 18, 20, 14),
            new("Orbit2", 20, 10, 20)
        };

        var result = evaluator.FindFastestRoute(vehicles, orbits, WeatherType.Windy);

        Assert.Equal("Car", result.Vehicle);
        Assert.Equal("Orbit2", result.Orbit);
    }

    [Fact]
    public void Selects_PreferredVehicle_When_TravelTimes_Are_Equal()
    {
        var evaluator = new RouteEvaluator();
        var vehicles = new List<Vehicle>
    {
        new("Car", 20, 2, false),
        new("TukTuk", 12, 1, true)
    };

        var orbits = new List<Orbit>
    {
        new("Orbit1", 18, 18, 12),
        new("Orbit2", 18, 18, 12)
    };

        var result = evaluator.FindFastestRoute(vehicles, orbits, WeatherType.Sunny);

        Assert.Equal("TukTuk", result.Vehicle);
    }

    [Fact]
    public void Returns_Null_When_NoVehicles_Available()
    {
        var evaluator = new RouteEvaluator();
        var result = evaluator.FindFastestRoute([], [], WeatherType.Sunny);

        Assert.Null(result);
    }
}