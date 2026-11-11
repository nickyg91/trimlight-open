using System.Text.Json.Serialization;
using Trimlight.Models.Enums;

namespace Trimlight.Models.Response;

public record BasePagedResponse<T> : BaseResponse
{
    public required BasePagedPayload<T> Payload { get; init; }
}