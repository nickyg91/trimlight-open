namespace Trimlight.Integration.Models.Response.DeviceInformation;

public record Port
{
    public int Id { get; init; }
    public int Start { get; init; }
    public int End { get; init; }
}