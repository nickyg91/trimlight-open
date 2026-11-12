using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trimlight.Infrastructure.Database.Context.Entities;
using Trimlight.Models.Enums;

namespace Trimlight.Infrastructure.Database.Context.EntityConfigurations;

public class DeviceEntityConfiguration : BaseEntityConfiguration<DeviceEntity>
{
    protected override string TableName => "device";

    public override void Configure(EntityTypeBuilder<DeviceEntity> builder)
    {
        builder.Property(x => x.DeviceId)
            .HasColumnName("device_id")
            .HasMaxLength(128);
        
        builder.Property(x => x.DeviceName)
            .HasColumnName("device_name")
            .HasMaxLength(128);
        
        builder.Property(x => x.IsOn)
            .HasColumnName("is_on")
            .HasDefaultValue(false);
        
        builder
            .Property(x => x.SwitchState)
            .HasColumnName("switch_state")
            .HasDefaultValue(SwitchState.LightOff);
        
        builder
            .Property(x => x.ConnectivityState)
            .HasColumnName("connectivity_state")
            .HasDefaultValue(ConnectivityState.Offline);
        
        builder
            .Property(x => x.ColorOrder)
            .HasColumnName("color_order")
            .HasDefaultValue(ColorOrder.RGB);
        
        builder
            .HasOne(x => x.DeviceEffect)
            .WithOne(x => x.Device)
            .HasForeignKey<DeviceEffectEntity>(x => x.DeviceId)
            .HasConstraintName("fk_device_device_effect");
        
        builder.HasMany(x => x.PixelPorts)
            .WithOne(x => x.Device)
            .HasForeignKey(x => x.DeviceId)
            .HasConstraintName("fk_device_pixel_port");
        
        base.Configure(builder);
    }
}