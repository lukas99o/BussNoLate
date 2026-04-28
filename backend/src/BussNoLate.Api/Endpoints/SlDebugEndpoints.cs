using BussNoLate.Api.Integrations.Sl;

namespace BussNoLate.Api.Endpoints;

public static class SlDebugEndpoints
{
    public static void MapSlDebugEndpoints(this WebApplication app)
    {
        app.MapGet("/debug/sl/departures/{siteId:int}", async (int siteId, ISlTransportClient client, CancellationToken cancellationToken) =>
        {
            var response = await client.GetDeparturesAsync(siteId, cancellationToken);

            return response is null
                ? Results.Problem("SL Transport API returned a non-success response. Check application logs for details.")
                : Results.Ok(response);
        });
    }
}
