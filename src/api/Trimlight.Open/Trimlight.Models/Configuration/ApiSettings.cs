namespace Trimlight.Models.Configuration;

public record ApiSettings
{
    public required string ApiSecret { get; init; }
    public required string ClientId { get; init; }
    public string BaseUrl => "https://trimlight.ledhue.com";
}