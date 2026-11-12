using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Trimlight.Infrastructure.Database.Context;

public class TrimlightOpenDbContextFactory : IDesignTimeDbContextFactory<TrimlightOpenDbContext>
{
    public TrimlightOpenDbContext CreateDbContext(string[] args)
    {
        string connectionString = args[0];
        DbContextOptionsBuilder<TrimlightOpenDbContext> optionsBuilder = new();
        optionsBuilder.UseNpgsql(connectionString);
        return new TrimlightOpenDbContext(optionsBuilder.Options);
    }
}