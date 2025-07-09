namespace MajesticRoutePlanner.Domain.Entities;

public class Orbit
{
    public string Name { get; }
    public int Distance { get; }
    public int Craters { get; }
    public int TrafficSpeed { get; }

    public Orbit(string name, int distance, int craters, int trafficSpeed)
    {
        Name = name;
        Distance = distance;
        Craters = craters;
        TrafficSpeed = trafficSpeed;
    }
}