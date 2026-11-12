using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trimlight.Infrastructure.Database.Context.Entities;

namespace Trimlight.Infrastructure.Database.Context.EntityConfigurations;

public class DeviceEffectConfiguration : BaseEntityConfiguration<DeviceEffectEntity>
{
    protected override string TableName => "device_effect";

    public override void Configure(EntityTypeBuilder<DeviceEffectEntity> builder)
    {
        builder.Property(x => x.DeviceId)
            .HasColumnName("device_id");
        
        builder.Property(x => x.CustomEffectId)
            .HasColumnName("custom_effect_id")
            .IsRequired(false);
        
        builder.Property(x => x.BuiltInEffectId)
            .HasColumnName("built_in_effect_id")
            .IsRequired(false);
        
        builder
            .HasOne(x => x.Device)
            .WithOne(x => x.DeviceEffect)
            .HasForeignKey<DeviceEffectEntity>(x => x.DeviceId);
        
       builder
           .HasIndex(x => x.DeviceId)
           .IsUnique()
           .HasDatabaseName("uq_idx_device_effect_device_id");
        
        base.Configure(builder);
    }
}