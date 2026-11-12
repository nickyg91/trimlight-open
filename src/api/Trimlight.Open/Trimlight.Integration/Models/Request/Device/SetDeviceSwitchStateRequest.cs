using Trimlight.Models.Enums;

namespace Trimlight.Integration.Models.Request.Device;

public record SetDeviceSwitchStateRequest
{
    public SwitchState SwitchState { get; init; }
}