using System.Text.Json.Serialization;
using Trimlight.Integration.Models.Enums;

namespace Trimlight.Integration.Models.Response.DeviceInformation;

public record Device
{
    public string? DeviceId { get; init; }
    public required string Name { get; init; }
    public SwitchState SwitchState { get; init; }
    public ConnectivityState Connectivity { get; init; }
    public State State { get; init; }
    [JsonPropertyName("fwVersionName")]
    public required string FirmwareVersionName { get; init; }
    public ColorOrder? ColorOrder { get; init; }
    public IcType? Ic { get; init; }
    public Port[]? Ports { get; init; }
    public Effect[]? Effects { get; init; }
    public Pixel[]? Pixels { get; init; }
    //public Effect? CurrentEffect { get; init; }
}