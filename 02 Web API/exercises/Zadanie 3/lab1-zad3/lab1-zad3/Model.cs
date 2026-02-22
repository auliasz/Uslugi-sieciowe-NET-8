namespace lab1_zad3;

public sealed class OpenWeatherDto
{
    public string Name { get; set; } = "";
    public MainDto Main { get; set; } = new();
    public WindDto Wind { get; set; } = new();
    public WeatherDescDto[] Weather { get; set; } = Array.Empty<WeatherDescDto>();
}

public sealed class MainDto
{
    public double Temp { get; set; }
    public int Humidity { get; set; }
}

public sealed class WindDto
{
    public double Speed { get; set; }
}

public sealed class WeatherDescDto
{
    public string Main { get; set; } = "";
    public string Description { get; set; } = "";
}