using System.Net.Http.Json;
using MajesticRoutePlanner.Application.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using MajesticRoutePlanner.Api.Controllers;

namespace MajesticRoutePlanner.Tests.Integration.ApiTests;

public class RouteApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public RouteApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Returns_TukTuk_On_Orbit1_WhenWeather_IsSunny()
    {
        var request = new RouteRequest
        {
            Weather = "Weather is Sunny",
            Orbit1Speed = 12,
            Orbit2Speed = 10
        };

        var response = await _client.PostAsJsonAsync("/api/route/optimal", request);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<RouteResult>();
        Assert.Equal("TukTuk", result?.Vehicle);
        Assert.Equal("Orbit1", result?.Orbit);
        Assert.Equal(108, result?.TravelTime);
    }

    [Fact]
    public async Task Returns_Car_On_Orbit2_WhenWeather_IsWindy()
    {
        var request = new RouteRequest
        {
            Weather = "Weather is Windy",
            Orbit1Speed = 14,
            Orbit2Speed = 20
        };

        var response = await _client.PostAsJsonAsync("/api/route/optimal", request);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<RouteResult>();
        Assert.Equal("Car", result?.Vehicle);
        Assert.Equal("Orbit2", result?.Orbit);
    }

    //[Fact]
    //public async Task Returns_Bike_On_Orbit2_WhenWeather_IsRainy()
    //{
    //    var request = new RouteRequest
    //    {
    //        Weather = "Rainy",
    //        Orbit1Speed = 10,
    //        Orbit2Speed = 15
    //    };

    //    var response = await _client.PostAsJsonAsync("/api/route/optimal", request);
    //    response.EnsureSuccessStatusCode();

    //    var result = await response.Content.ReadFromJsonAsync<RouteResult>();
    //    Assert.Equal("Bike", result?.Vehicle);
    //    Assert.Equal("Orbit2", result?.Orbit);
    //}

    [Fact]
    public async Task Returns_BadRequest_For_InvalidWeather()
    {
        var request = new RouteRequest
        {
            Weather = "Volcanic Ash",
            Orbit1Speed = 15,
            Orbit2Speed = 15
        };

        var response = await _client.PostAsJsonAsync("/api/route/optimal", request);
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }
}