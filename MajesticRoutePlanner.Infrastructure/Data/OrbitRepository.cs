using MajesticRoutePlanner.Domain.Entities;
using MajesticRoutePlanner.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MajesticRoutePlanner.Infrastructure.Data;

public class OrbitRepository : IOrbitRepository
{
    private readonly ILogger<OrbitRepository> _logger;
    private readonly IOptionsSnapshot<List<OrbitConfig>> _options;

    public OrbitRepository(IOptionsSnapshot<List<OrbitConfig>> options, ILogger<OrbitRepository> logger)
    {
        _options = options;
        _logger = logger;
    }

    public IEnumerable<Orbit> GetOrbits(int orbit1Speed, int orbit2Speed)
    {
        var rawConfig = _options.Value;
        var orbits = new List<Orbit>
        {
            new(rawConfig[0].Name, rawConfig[0].Distance, rawConfig[0].Craters, orbit1Speed),
            new(rawConfig[1].Name, rawConfig[1].Distance, rawConfig[1].Craters, orbit2Speed)
        };

        _logger.LogInformation("🛣️ Orbit speeds injected: Orbit1={Orbit1}, Orbit2={Orbit2}", orbit1Speed, orbit2Speed);
        _logger.LogDebug("📡 Orbit structure: {@Orbits}", orbits);

        return orbits;
    }
}