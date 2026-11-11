namespace Trimlight.Models.Request;

public record GetDeviceListRequest
{
    // 10 devices per page.
    public int Page { get; init; }
};