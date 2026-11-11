using System.Security.Cryptography;
using System.Text;
using Trimlight.Models.Configuration;

namespace Trimlight.Integration.Authentication;

public class TrimlightTokenService(ApiSettings apiSettings) : ITrimlightTokenService
{
    private readonly ApiSettings _apiSettings = apiSettings;
    public string GetToken(long timestamp)
    {
        string seedValue = $"Trimlight|{_apiSettings.ClientId}|{timestamp}";
        using HMACSHA256 sha256 = new HMACSHA256(Encoding.UTF8.GetBytes(_apiSettings.ApiSecret));
        byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(seedValue));
        return Convert.ToBase64String(hash);
    }
}