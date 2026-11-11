using Trimlight.Integration.Refit.Api;
using Trimlight.Models.Request;

namespace Trimlight.Api.Endpoints;

public static class DeviceEndpoints
{
    extension(WebApplication app)
    {
        public WebApplication MapDeviceEndpoints()
        {
            RouteGroupBuilder group = app.MapGroup("/api/device").WithTags("Devices");

            group.MapGet("/",
                async (ITrimlightApiClient client, CancellationToken cancellationToken) =>
                    await client.GetDeviceList(cancellationToken));

            group.MapGet("/{id}",
                async (ITrimlightApiClient client, CancellationToken cancellationToken, string id) =>
                    await client.GetDevice(new GetDeviceRequest { DeviceId = id }, cancellationToken));

            return app;
        }
    }
}