using Refit;
using Trimlight.Integration.Models.Request.Device;
using Trimlight.Integration.Models.Response;
using Trimlight.Integration.Models.Response.DeviceInformation;

namespace Trimlight.Integration.Refit.Api;

public interface ITrimlightApiClient
{
    [Get("/trimlight/v1/oauth/resources/devices")]
    Task<GetDeviceListResponse> GetDeviceList(CancellationToken ctx);
    
    [Get("/trimlight/v1/oauth/resources/device/get")]
    Task<BasePayload<Device>> GetDevice([Body]GetDeviceRequest request, CancellationToken ctx);
    
    [Post("/trimlight/v1/oauth/resources/device/update")]
    Task<BaseResponse> SetDeviceSwitchState([Body]BasePayload<SetDeviceSwitchStateRequest> request, CancellationToken ctx);
}