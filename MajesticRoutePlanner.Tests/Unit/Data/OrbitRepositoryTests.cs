using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using MajesticRoutePlanner.Infrastructure.Data;
using Moq;

namespace MajesticRoutePlanner.Tests.Unit.Data;

public class OrbitRepositoryTests
{
    [Fact]
    public void Returns_Orbit_With_Injected_Speeds()
    {
        var config = new List<OrbitConfig>
        {
            new() { Name = "Orbit1", Distance = 18, Craters = 20 },
            new() { Name = "Orbit2", Distance = 20, Craters = 10 }
        };

        var snapshot = new Mock<IOptionsSnapshot<List<OrbitConfig>>>();
        snapshot.Setup(o => o.Value).Returns(config);

        var repo = new OrbitRepository(snapshot.Object, new LoggerFactory().CreateLogger<OrbitRepository>());
        var result = repo.GetOrbits(14, 20).ToList();

        Assert.Equal(2, result.Count);
        Assert.Equal(14, result[0].TrafficSpeed);
        Assert.Equal(20, result[1].TrafficSpeed);
    }

    [Fact]
    public void Correctly_Inserts_Speeds_Into_Orbit()
    {
        var config = new List<OrbitConfig>
        {
            new() { Name = "Orbit1", Distance = 18, Craters = 20 },
            new() { Name = "Orbit2", Distance = 20, Craters = 10 }
        };

        var snapshot = new Mock<IOptionsSnapshot<List<OrbitConfig>>>();
        snapshot.Setup(o => o.Value).Returns(config);

        var repo = new OrbitRepository(snapshot.Object, new LoggerFactory().CreateLogger<OrbitRepository>());
        var result = repo.GetOrbits(15, 25).ToList();

        Assert.Equal(15, result[0].TrafficSpeed);
        Assert.Equal(25, result[1].TrafficSpeed);
    }
}