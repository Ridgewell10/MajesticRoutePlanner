namespace MajesticRoutePlanner.Domain.Entities;

public class Vehicle
{
    public string Name { get; }
    public int MaxSpeed { get; }
    public int CraterTime { get; }
    public bool CanUseInRain { get; }


    public Vehicle(string name, int maxSpeed, int craterTime, bool canUseInRain)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        CraterTime = craterTime;
        CanUseInRain = canUseInRain;
    }
}