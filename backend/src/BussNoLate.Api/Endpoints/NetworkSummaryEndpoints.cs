using BussNoLate.Api.Domain.Normalization;
using BussNoLate.Api.Integrations.Sl;

namespace BussNoLate.Api.Endpoints;

public static class NetworkSummaryEndpoints
{
    public static void MapNetworkSummaryEndpoints(this WebApplication app)
    {
        app.MapGet("/api/departures/{siteId:int}", async (int siteId, ISlTransportClient client, CancellationToken cancellationToken) =>
        {
            var response = await client.GetDeparturesAsync(siteId, cancellationToken);

            return response is null
                ? Results.Problem("SL Transport API returned a non-success response. Check application logs for details.")
                : Results.Ok(response.Departures.Select(SlDepartureNormalizer.Normalize));
        });
    }
}
