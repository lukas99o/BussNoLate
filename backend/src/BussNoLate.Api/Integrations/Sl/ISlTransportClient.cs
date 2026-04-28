using BussNoLate.Api.Integrations.Sl.Models;

namespace BussNoLate.Api.Integrations.Sl;

public interface ISlTransportClient
{
    Task<SlDeparturesResponse?> GetDeparturesAsync(int siteId, CancellationToken cancellationToken = default);
}
