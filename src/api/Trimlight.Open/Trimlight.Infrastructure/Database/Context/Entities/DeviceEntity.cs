using Trimlight.Models.Enums;

namespace Trimlight.Infrastructure.Database.Context.Entities;

public class DeviceEntity : BaseEntity
{
    public required string DeviceId { get; set; }
    public required string DeviceName { get; set; }
    public bool IsOn { get; set; }
    public SwitchState SwitchState { get; set; } = SwitchState.LightOff;
    public ConnectivityState ConnectivityState { get; set; } = ConnectivityState.Offline;
    public ColorOrder ColorOrder { get; set; } = ColorOrder.RGB;
    public List<PixelPortEntity> PixelPorts { get; set; } = [];
    public DeviceEffectEntity? DeviceEffect { get; set; }

}