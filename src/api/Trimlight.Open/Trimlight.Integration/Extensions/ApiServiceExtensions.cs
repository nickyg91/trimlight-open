using Microsoft.Extensions.DependencyInjection;
using Trimlight.Integration.Authentication;

namespace Trimlight.Integration.Extensions;

public static class ApiServiceExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddApiServices()
        {
            services.AddScoped<ITrimlightTokenService, TrimlightTokenService>();
            return services;
        }
    }
}