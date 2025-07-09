using Microsoft.AspNetCore.Mvc;
using MajesticRoutePlanner.Application.Services;
using MajesticRoutePlanner.Domain.Enums;
using MajesticRoutePlanner.Domain.Interfaces;
using MajesticRoutePlanner.Application.DTOs;

namespace MajesticRoutePlanner.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RouteController : ControllerBase
{
    private readonly RouteEvaluator _evaluator;
    private readonly IVehicleRepository _vehicleRepo;
    private readonly IOrbitRepository _orbitRepo;
    private readonly ILogger<RouteController> _logger;

    public RouteController(
        RouteEvaluator evaluator,
        IVehicleRepository vehicleRepo,
        IOrbitRepository orbitRepo,
        ILogger<RouteController> logger)
    {
        _evaluator = evaluator;
        _vehicleRepo = vehicleRepo;
        _orbitRepo = orbitRepo;
        _logger = logger;
    }

    [HttpPost("optimal")]
    public IActionResult GetOptimalRoute([FromBody] RouteRequest request)
    {
        try
        {
            _logger.LogInformation("Received route evaluation request: {@Request}", request);

            var matched = Enum.GetNames(typeof(WeatherType))
                .FirstOrDefault(n => request.Weather.Contains(n, StringComparison.OrdinalIgnoreCase));

            if (matched is null)
            {
                _logger.LogWarning("Invalid weather value received: {Weather}", request.Weather);
                return BadRequest("Invalid weather value.");
            }

            var weather = Enum.Parse<WeatherType>(matched, true);
            _logger.LogInformation("Parsed weather condition: {Weather}", weather);

            var vehicles = _vehicleRepo.GetAvailableVehicles(weather);
            var orbits = _orbitRepo.GetOrbits(request.Orbit1Speed, request.Orbit2Speed);
            _logger.LogDebug("Available vehicles: {@Vehicles}", vehicles);
            _logger.LogDebug("Orbit configuration: {@Orbits}", orbits);

            var result = _evaluator.FindFastestRoute(vehicles, orbits, weather);
            _logger.LogInformation("Optimal route calculated: {Vehicle} on {Orbit}, time: {Time}",
                result.Vehicle, result.Orbit, result.TravelTime);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while processing the route request.");
            return StatusCode(500, "Something went wrong while calculating the route.");
        }
    }
}