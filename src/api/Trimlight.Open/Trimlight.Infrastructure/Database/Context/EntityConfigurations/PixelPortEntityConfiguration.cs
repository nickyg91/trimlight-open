using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trimlight.Infrastructure.Database.Context.Entities;

namespace Trimlight.Infrastructure.Database.Context.EntityConfigurations;

public class PixelPortEntityConfiguration : BaseEntityConfiguration<PixelPortEntity>
{
    protected override string TableName => "pixel_port";
    
    public override void Configure(EntityTypeBuilder<PixelPortEntity> builder)
    {
        builder.Property(x => x.DeviceId).HasColumnName("device_id");
        builder.Property(x => x.Start).HasColumnName("start");
        builder.Property(x => x.End).HasColumnName("end");
        builder.Property(x => x.TrimlightPortId).HasColumnName("trimlight_port_id");
        
        base.Configure(builder);
    }
}