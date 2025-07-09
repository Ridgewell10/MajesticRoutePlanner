namespace MajesticRoutePlanner.Infrastructure.Data
{
    public class VehicleConfig
    {
        public string Name { get; set; } = "";
        public int MaxSpeed { get; set; }
        public int CraterTime { get; set; }
        public bool CanUseInRain { get; set; }
    }
}