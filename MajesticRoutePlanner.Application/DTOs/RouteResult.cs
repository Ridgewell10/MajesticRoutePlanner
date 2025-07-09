namespace MajesticRoutePlanner.Application.DTOs;

using System.Text.Json.Serialization;

public class RouteResult
{
    [JsonPropertyName("vehicle")]
    public string Vehicle { get; }

    [JsonPropertyName("orbit")]
    public string Orbit { get; }

    [JsonPropertyName("travelTime")]
    public int TravelTime { get; }

    [JsonConstructor]
    public RouteResult(string vehicle, string orbit, int travelTime)
    {
        Vehicle = vehicle;
        Orbit = orbit;
        TravelTime = travelTime;
    }
}