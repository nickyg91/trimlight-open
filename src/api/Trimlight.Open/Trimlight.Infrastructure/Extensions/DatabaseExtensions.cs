using Microsoft.Extensions.DependencyInjection;
using Trimlight.Infrastructure.Database.Context;

namespace Trimlight.Infrastructure.Extensions;

public static class DatabaseExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddTrimlightDatabase(string connectionString)
        {
            services.AddNpgsql<TrimlightOpenDbContext>(connectionString);
            return services;
        }
    }
}