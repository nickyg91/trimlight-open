using Refit;
using Trimlight.Models.Response;

namespace Trimlight.Integration.Refit.Api;

public interface ITrimlightApiClient
{
    [Get("/trimlight/v1/oauth/resources/devices")]
    Task<GetDeviceListResponse> GetDeviceList(CancellationToken ctx);
}