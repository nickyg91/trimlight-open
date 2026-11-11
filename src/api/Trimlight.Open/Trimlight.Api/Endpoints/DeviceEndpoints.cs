using Trimlight.Integration.Refit.Api;

namespace Trimlight.Api.Endpoints;

public static class DeviceEndpoints
{
    extension(WebApplication app)
    {
        public WebApplication MapDeviceEndpoints()
        {
            RouteGroupBuilder group = app.MapGroup("/api/device").WithTags("Devices");

            group.MapGet("/", async (ITrimlightApiClient client, CancellationToken cancellationToken) => await client.GetDeviceList(cancellationToken));
            
            return app;
        }
    }
}