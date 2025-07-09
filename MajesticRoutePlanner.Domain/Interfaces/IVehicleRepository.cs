using MajesticRoutePlanner.Domain.Entities;
using MajesticRoutePlanner.Domain.Enums;

namespace MajesticRoutePlanner.Domain.Interfaces;

public interface IVehicleRepository
{
    IEnumerable<Vehicle> GetAvailableVehicles(WeatherType weather);
}