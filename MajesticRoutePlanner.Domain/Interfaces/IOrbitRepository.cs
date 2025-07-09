using MajesticRoutePlanner.Domain.Entities;

namespace MajesticRoutePlanner.Domain.Interfaces;

public interface IOrbitRepository
{
    IEnumerable<Orbit> GetOrbits(int orbit1Speed, int orbit2Speed);
}