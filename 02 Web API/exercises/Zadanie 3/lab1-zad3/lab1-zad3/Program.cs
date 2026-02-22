using System.Text.Json;
using lab1_zad3;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient("OpenWeather", client =>
{
    client.BaseAddress = new Uri("https://api.openweathermap.org/");
});

var app = builder.Build();

app.MapGet("/weather/{city}", async (string city, IHttpClientFactory httpClientFactory) =>
{
    var apiKey = builder.Configuration["OpenWeather:ApiKey"];
    var client = httpClientFactory.CreateClient("OpenWeather");
    var url = $"data/2.5/weather?q={Uri.EscapeDataString(city)}&appid={apiKey}&units=metric&lang=pl";
    var json = await client.GetStringAsync(url);
    var dto = JsonSerializer.Deserialize<OpenWeatherDto>(json, new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    })!;

    return Results.Ok(new
    {
        city = dto.Name,
        temperatureC = dto.Main.Temp,
        humidity = dto.Main.Humidity,
        windSpeed = dto.Wind.Speed,
        summary = dto.Weather.FirstOrDefault()?.Main,
        description = dto.Weather.FirstOrDefault()?.Description
    });
});
app.Run();