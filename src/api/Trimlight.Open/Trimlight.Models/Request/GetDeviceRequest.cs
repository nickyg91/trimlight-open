namespace Trimlight.Models.Request;

public record GetDeviceRequest()
{
    public required string DeviceId { get; init; }
    public CurrentDate CurrentDate = new();
}