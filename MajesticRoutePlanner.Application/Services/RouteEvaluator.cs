using MajesticRoutePlanner.Application.DTOs;
using MajesticRoutePlanner.Domain.Entities;
using MajesticRoutePlanner.Domain.Enums;

namespace MajesticRoutePlanner.Application.Services;

public class RouteEvaluator
{
    private static readonly List<string> VehiclePriority = ["Bike", "TukTuk", "Car"];

    public RouteResult? FindFastestRoute(
        IEnumerable<Vehicle> vehicles,
        IEnumerable<Orbit> orbits,
        WeatherType weather)
        {
            var results = new List<RouteResult>();

            foreach (var orbit in orbits)
            {
                foreach (var vehicle in vehicles)
                {
                    var craterCount = orbit.Craters;

                    if (weather == WeatherType.Sunny)
                        craterCount = (int)(craterCount * 0.9);
                    else if (weather == WeatherType.Rainy)
                        craterCount = (int)(craterCount * 1.2);

                    var speed = Math.Min(vehicle.MaxSpeed, orbit.TrafficSpeed);
                    var time = orbit.Distance / (double)speed * 60 + craterCount * vehicle.CraterTime;

                    results.Add(new RouteResult(vehicle.Name, orbit.Name, (int)Math.Round(time)));
                }
            }

            if (!results.Any())
                return null;

            return results
                .OrderBy(r => r.TravelTime)
                .ThenBy(r => r.Vehicle)
                .First();
        }
}