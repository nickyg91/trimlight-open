using System.Text.Json.Serialization;
using Trimlight.Models.Enums;

namespace Trimlight.Models.Response.DeviceInformation;

public record Device
{
    public string? DeviceId { get; init; }
    public required string Name { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SwitchState SwitchState { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ConnectivityState Connectivity { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public State State { get; init; }
    [JsonPropertyName("fwVersionName")]
    public required string FirmwareVersionName { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ColorOrder? ColorOrder { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public IcType? Ic { get; init; }
    public Port[]? Ports { get; init; }
}