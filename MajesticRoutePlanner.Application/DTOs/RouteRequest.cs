namespace MajesticRoutePlanner.Application.DTOs;

public class RouteRequest
{
    public string Weather { get; set; } = "";
    public int Orbit1Speed { get; set; }
    public int Orbit2Speed { get; set; }
}