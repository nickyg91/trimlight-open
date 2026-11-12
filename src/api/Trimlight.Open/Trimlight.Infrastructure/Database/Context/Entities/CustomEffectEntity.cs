using Trimlight.Models.Enums;

namespace Trimlight.Infrastructure.Database.Context.Entities;

public class CustomEffectEntity : BaseEntity
{
    public EffectCategory Category { get; set; }
    public CustomEffectMode? CustomEffectMode { get; set; }
    public required string Name { get; set; }
    public int TrimlightEffectId { get; set; }
    public byte Speed { get; set; }
    public byte Brightness { get; set; }
    public int PixelLength { get; set; }
    public bool Reverse { get; set; }
    public ICollection<PixelEntity> Pixels { get; set; } = [];
}