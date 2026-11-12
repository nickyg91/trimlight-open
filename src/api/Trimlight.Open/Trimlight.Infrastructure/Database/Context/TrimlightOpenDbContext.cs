using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Trimlight.Infrastructure.Database.Context;

public class TrimlightOpenDbContext : DbContext
{
    public TrimlightOpenDbContext() : base()
    {
        
    }
    
    public TrimlightOpenDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(TrimlightOpenDbContext))!);
        base.OnModelCreating(modelBuilder);
    }
}