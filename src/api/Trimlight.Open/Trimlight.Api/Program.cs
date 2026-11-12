using System.Text.Json;
using System.Text.Json.Serialization;
using Trimlight.Api.Endpoints;
using Trimlight.Infrastructure.Extensions;
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
string connectionString = (builder.Environment.IsDevelopment() ? builder.Configuration.GetConnectionString("TrimlightOpen") : builder.Configuration["TRIMLIGHT_CONNECTION_STRING"]) 
                          ?? throw new InvalidOperationException("TRIMLIGHT_CONNECTION_STRING is not set");

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
builder.Services.AddTrimlightDatabase(connectionString);
// Add services to the container.

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapDeviceEndpoints();

app.Run();