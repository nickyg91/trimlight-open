using System.Text.Json;
using System.Text.Json.Serialization;
using Trimlight.Api.Endpoints;
using Trimlight.Integration.Extensions;
using Trimlight.Models.Configuration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string environment = builder.Environment.EnvironmentName;
builder.Configuration
    .AddJsonFile($"appsettings.{environment}.json")
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables();

string secret = builder.Configuration["TRIMLIGHT_API_SECRET"] ?? throw new InvalidOperationException("TRIMLIGHT_API_SECRET is not set");
string clientId = builder.Configuration["TRIMLIGHT_CLIENT_ID"] ?? throw new InvalidOperationException("TRIMLIGHT_CLIENT_ID is not set");

ApiSettings settings = new()
{
    ApiSecret = secret,
    ClientId = clientId
};

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddSingleton(settings);
builder.Services.AddApiServices();
builder.Services.AddRefitClient(settings.BaseUrl);
// Add services to the container.

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapDeviceEndpoints();

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast = Enumerable.Range(1, 5).Select(index =>
//             new WeatherForecast
//             (
//                 DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//                 Random.Shared.Next(-20, 55),
//                 summaries[Random.Shared.Next(summaries.Length)]
//             ))
//         .ToArray();
//     return forecast;
// });

app.Run();