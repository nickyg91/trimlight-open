using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Trimlight.Integration.Refit;
using Trimlight.Integration.Refit.Api;

namespace Trimlight.Integration.Extensions;

public static class RefitExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddRefitClient(string baseUrl)
        {
            JsonSerializerOptions jsonOptions = new()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter() },
            };
            RefitSettings settings = new(new SystemTextJsonContentSerializer(jsonOptions));
            services.AddHttpClient("TrimlightApi");

            services.AddRefitGeneratedClient<ITrimlightApiClient>(settings, "TrimlightApi")
                .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            }).AddHttpMessageHandler<TokenHandler>();

            services.AddTransient<TokenHandler>();
            
            return services;
        }
    }
}