namespace Trimlight.Integration.Models.Request.Device;

public record GetDeviceRequest()
{
    public required string DeviceId { get; init; }
    public CurrentDate CurrentDate = new();
}