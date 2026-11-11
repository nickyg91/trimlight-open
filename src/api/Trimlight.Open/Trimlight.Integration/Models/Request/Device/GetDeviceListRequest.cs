namespace Trimlight.Integration.Models.Request.Device;

public record GetDeviceListRequest
{
    // 10 devices per page.
    public int Page { get; init; }
};