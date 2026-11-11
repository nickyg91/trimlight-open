using System.Text.Json.Serialization;
using Trimlight.Models.Enums;

namespace Trimlight.Models.Response;

public record BasePagedResponse<T>
{
    public Code Code { get; init; }
    [JsonPropertyName("desc")]
    public required string Description { get; init; }
    public required BasePagedPayload<T> Payload { get; init; }
}