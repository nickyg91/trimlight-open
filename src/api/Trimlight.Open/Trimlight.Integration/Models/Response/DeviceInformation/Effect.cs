using System.Text.Json.Serialization;
using Trimlight.Models.Enums;

namespace Trimlight.Integration.Models.Response.DeviceInformation;

public record Effect
{
    public int Id { get; init; }
    public string? Name { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EffectCategory Category { get; init; }
    public byte Mode { get; init; }
    public byte Speed { get; init; }
    public byte Brightness { get; init; }
    public byte PixelLen { get; init; }
    public bool Reverse { get; init; }
    public Pixel[]? Pixels { get; init; }
}