using WebApi.Extensions;
using WebApi.ExternalApis.WebAPi2;
using WebApi.ExternalApis.WebApiFail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRefitClientWithResilience<IWebApiFail>("https://localhost:7036");
builder.Services.AddRefitClientWithResilience<IWebApi2>("https://localhost:7039");
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

app.UseAuthorization();

app.MapControllers();

app.Run();
