var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();


var windDirections = new[] { "N", "NE", "E", "SE", "S", "SW", "W", "NW" };

app.MapGet("/temperature", () =>
{
    var temp = Random.Shared.Next(-10, 20);
    return Results.Ok(new {temperature = temp} );
});
app.MapGet("/wind", () =>
{
    var direction = windDirections[Random.Shared.Next(windDirections.Length)];
    return Results.Ok(new { windDirection = direction });
});
app.Run();