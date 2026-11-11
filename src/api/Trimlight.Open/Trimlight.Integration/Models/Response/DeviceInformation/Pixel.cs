namespace Trimlight.Integration.Models.Response.DeviceInformation;

public record Pixel
{
    public int Index { get; init; }
    public int Count { get; init; }
    public int Color { get; init; }
    public bool Disable { get; init; }
    public byte Red => (byte)(Color >> 16);
    public byte Green => (byte)(Color >> 8);
    public byte Blue => (byte)(Color % 256);
}