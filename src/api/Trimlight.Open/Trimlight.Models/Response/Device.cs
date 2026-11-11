using System.Text.Json.Serialization;
using Trimlight.Models.Enums;

namespace Trimlight.Models.Response;

public record Device
{
    public required string DeviceId { get; init; }
    public required string Name { get; init; }
    public SwitchState SwitchState { get; init; }
    public ConnectivityState Connectivity { get; init; }
    public State State { get; init; }
    [JsonPropertyName("fwVersionName")]
    public required string FirmwareVersionName { get; init; }
}