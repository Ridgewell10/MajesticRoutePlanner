using MajesticRoutePlanner.Domain.Entities;
using MajesticRoutePlanner.Domain.Enums;

namespace MajesticRoutePlanner.Domain.Interfaces;

public interface IRoutePlanner
{
    (Vehicle vehicle, Orbit orbit, double time) GetFastestRoute(
        IEnumerable<Vehicle> vehicles,
        IEnumerable<Orbit> orbits,
        WeatherType weather);
}