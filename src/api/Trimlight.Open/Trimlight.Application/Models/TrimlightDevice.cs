using Trimlight.Integration.Models.Response.DeviceInformation;

namespace Trimlight.Application.Models;

public record TrimlightDevice
{
    public TrimlightDevice() { }
    
    public TrimlightDevice(Device device)
    {
            
    }
    
    public string? DeviceId { get; init; }
}