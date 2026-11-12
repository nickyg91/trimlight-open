using Trimlight.Models.Enums;

namespace Trimlight.Infrastructure.Database.Context.Entities;

public class DeviceEffectEntity : BaseEntity
{
    public int DeviceId { get; set; }
    public int? CustomEffectId { get; set; }
    public BuiltInEffectMode? BuiltInEffectId { get; set; }
    public CustomEffectEntity? CustomEffect { get; set; }
    public DeviceEntity? Device { get; set; }
}