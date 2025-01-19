using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


int failureCount = 0; // Variável global para contar as falhas

app.MapGet("/test", () =>
{
    // Incrementa o contador de falhas
    if (failureCount < 3)
    {
        failureCount++;
        Console.WriteLine($"Falha #{failureCount}");
        return Results.StatusCode((int)HttpStatusCode.BadGateway); // Retorna erro 429
    }

    Console.WriteLine("Resposta bem-sucedida após falhas");
    return Results.Ok("Resposta bem-sucedida!");
});

app.MapPost("/reset", () =>
{
    failureCount = 0;
    Console.WriteLine("Contador de falhas resetado.");
    return Results.Ok("Contador resetado.");
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
