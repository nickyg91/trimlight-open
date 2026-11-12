namespace Trimlight.Infrastructure.Database.Context.Entities;

public class PixelEntity : BaseEntity
{
    public int CustomEffectId { get; set; }
    public int Index { get; set; }
    public int Count { get; set; }
    public byte Red { get; set; }
    public byte Blue { get; set; }
    public byte Green { get; set; }
    public bool Disabled { get; set; }
    public CustomEffectEntity? CustomEffect { get; set; }
}