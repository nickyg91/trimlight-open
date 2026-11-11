using System.Text.Json.Serialization;
using Trimlight.Integration.Models.Enums;

namespace Trimlight.Integration.Models.Response;

public record BaseResponse
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Code Code { get; init; }
    [JsonPropertyName("desc")]
    public required string Description { get; init; }
}