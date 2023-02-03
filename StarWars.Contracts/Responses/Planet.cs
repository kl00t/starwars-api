namespace StarWars.Contracts.Responses;

public class Planet
{
	public Planet(string name, string diameter, string gravity, string orbitalPeriod, string population, string rotationPeriod, Geography geography)
    {
		Name = name;
        Diameter = diameter;
        Gravity = gravity;
        OrbitalPeriod = orbitalPeriod;
        Population = population;
        RotationPeriod = rotationPeriod;
        Geography = geography;
    }

    public string Name { get; internal set; }

    public string Diameter { get; internal set; }

    public string Gravity { get; internal set; }

    public string OrbitalPeriod { get; internal set; }

    public string Population { get; internal set; }

    public string RotationPeriod { get; internal set; }

    public Geography Geography { get; set; }
}