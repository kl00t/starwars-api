namespace StarWars.Domain.Models;

public class Geography
{
    public Geography(string terrain, string surfaceWater, string climate)
    {
        Terrain = terrain;
        SurfaceWater = surfaceWater;
        Climate = climate;
    }

    public string Terrain { get; internal set; }

    public string SurfaceWater { get; internal set; }

    public string Climate { get; internal set; }
}