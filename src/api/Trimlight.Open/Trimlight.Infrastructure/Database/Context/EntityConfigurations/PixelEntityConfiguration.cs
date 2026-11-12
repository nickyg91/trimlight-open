using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trimlight.Infrastructure.Database.Context.Entities;

namespace Trimlight.Infrastructure.Database.Context.EntityConfigurations;

public class PixelEntityConfiguration : BaseEntityConfiguration<PixelEntity>
{
    protected override string TableName => "pixel";
    
    public override void Configure(EntityTypeBuilder<PixelEntity> builder)
    {
        builder.Property(x => x.Red).HasColumnName("red");
        builder.Property(x => x.Green).HasColumnName("green");
        builder.Property(x => x.Blue).HasColumnName("blue");
        builder.Property(x => x.CustomEffectId).HasColumnName("custom_effect_id");
        builder.Property(x => x.Index).HasColumnName("index");
        builder.Property(x => x.Disabled).HasColumnName("disabled").HasDefaultValue(false);
        
        builder
            .HasOne(x => x.CustomEffect)
            .WithMany(x => x.Pixels)
            .HasForeignKey(x => x.CustomEffectId)
            .HasConstraintName("fk_pixel_custom_effect");

        base.Configure(builder);
    }
}