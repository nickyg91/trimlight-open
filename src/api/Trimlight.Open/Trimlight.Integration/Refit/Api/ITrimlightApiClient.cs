using Refit;
using Trimlight.Models.Request;
using Trimlight.Models.Response;
using Trimlight.Models.Response.DeviceInformation;

namespace Trimlight.Integration.Refit.Api;

public interface ITrimlightApiClient
{
    [Get("/trimlight/v1/oauth/resources/devices")]
    Task<GetDeviceListResponse> GetDeviceList(CancellationToken ctx);
    
    [Get("/trimlight/v1/oauth/resources/device/get")]
    Task<BasePayload<Device>> GetDevice([Body]GetDeviceRequest request, CancellationToken ctx);
}