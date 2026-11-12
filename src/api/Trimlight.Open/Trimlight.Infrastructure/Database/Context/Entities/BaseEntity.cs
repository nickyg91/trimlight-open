namespace Trimlight.Infrastructure.Database.Context.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTimeOffset CreatedAtUtc { get; set; }
}