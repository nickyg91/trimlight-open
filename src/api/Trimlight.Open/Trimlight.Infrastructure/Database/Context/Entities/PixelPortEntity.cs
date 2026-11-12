namespace Trimlight.Infrastructure.Database.Context.Entities;

public class PixelPortEntity : BaseEntity
{
    public int DeviceId { get; set; }
    public DeviceEntity? Device { get; set; }
    public int Start { get; set; }
    public int End { get; set; }
    public int TrimlightPortId { get; set; }
}