namespace Trimlight.Models.Response;

public record BasePayload<T> : BaseResponse
{
    public required T Payload { get; init; }
}