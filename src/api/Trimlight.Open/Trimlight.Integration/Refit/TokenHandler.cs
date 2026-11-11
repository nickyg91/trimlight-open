using System.Net.Http.Headers;
using Trimlight.Integration.Authentication;
using Trimlight.Models.Configuration;

namespace Trimlight.Integration.Refit;

public class TokenHandler(ITrimlightTokenService tokenService, ApiSettings apiSettings) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        string token =  tokenService.GetToken(timestamp);
        request.Headers.TryAddWithoutValidation("Authorization", token);
        request.Headers.Add("S-ClientId", apiSettings.ClientId);
        request.Headers.Add("S-Timestamp", timestamp.ToString());
        return await base.SendAsync(request, cancellationToken);
    }
}