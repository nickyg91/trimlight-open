namespace Trimlight.Integration.Models.Response;

public record BasePagedPayload<T>
{
    public int Total { get; init; }
    public int Current { get; init; }
    public required T[] Data { get; init; }
}