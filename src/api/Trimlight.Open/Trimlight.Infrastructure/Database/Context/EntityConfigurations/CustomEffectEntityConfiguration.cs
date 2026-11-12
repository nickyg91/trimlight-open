using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trimlight.Infrastructure.Database.Context.Entities;
using Trimlight.Models.Enums;

namespace Trimlight.Infrastructure.Database.Context.EntityConfigurations;

public class CustomEffectEntityConfiguration : BaseEntityConfiguration<CustomEffectEntity>
{
    protected override string TableName => "custom_effect";
    
    public override void Configure(EntityTypeBuilder<CustomEffectEntity> builder)
    {
        builder.Property(x => x.Category)
            .HasColumnName("category")
            .HasDefaultValue(EffectCategory.Custom);
        
        builder.Property(x => x.Brightness)
            .HasColumnName("brightness");
        
        builder.Property(x => x.CustomEffectMode)
            .HasColumnName("custom_effect_mode")
            .IsRequired(false);
        
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(128);
        
        builder
            .Property(x => x.PixelLength)
            .HasColumnName("pixel_length");

        builder.Property(x => x.Reverse).HasColumnName("reverse");
        builder.Property(x => x.Speed).HasColumnName("speed");
        
        base.Configure(builder);
    }
}