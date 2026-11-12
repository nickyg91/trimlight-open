using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trimlight.Infrastructure.Database.Context.Entities;

namespace Trimlight.Infrastructure.Database.Context.EntityConfigurations;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    protected abstract string TableName { get; }
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(TableName);
        
        builder.HasKey(x => x.Id).HasName($"pk_{TableName}");
        builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn();
        builder
            .Property(x => x.CreatedAtUtc)
            .HasDefaultValueSql("now()")
            .HasColumnName("created_at_utc");
    }
}