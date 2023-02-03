namespace StarWars.Domain.Models;

public class Planet
{
	public Planet(
        string name, 
        string climate, 
        string diameter, 
        string gravity, 
        string orbitalPeriod, 
        string population, 
        string rotationPeriod,
        string surfaceWater,
        string terrain)
	{
		Name = name;
        Climate = climate;
        Diameter = diameter;
        Gravity = gravity;
        OrbitalPeriod = orbitalPeriod;
        Population = population;
        RotationPeriod = rotationPeriod;
        Geography = new Geography(
            terrain: terrain, 
            surfaceWater: surfaceWater, 
            climate: climate);
	}

    public string Name { get; internal set; }

    public string Climate { get; internal set; }

    public string Diameter { get; internal set; }

    public string Gravity { get; internal set; }

    public string OrbitalPeriod { get; internal set; }

    public string Population { get; internal set; }

    public string RotationPeriod { get; internal set; }

    public Geography Geography { get; set; }
}