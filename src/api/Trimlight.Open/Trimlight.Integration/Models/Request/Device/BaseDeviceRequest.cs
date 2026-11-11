namespace Trimlight.Integration.Models.Request.Device;

public record BaseDeviceRequest<T>
{
    public required string DeviceId { get; init; }
    public required T Payload { get; init; }
}