namespace Trimlight.Integration.Models.Response;

public record BasePagedResponse<T> : BaseResponse
{
    public required BasePagedPayload<T> Payload { get; init; }
}