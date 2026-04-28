using BussNoLate.Api.Integrations.Sl.Models;

namespace BussNoLate.Api.Integrations.Sl;

public sealed class SlTransportClient : ISlTransportClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<SlTransportClient> _logger;

    public SlTransportClient(HttpClient httpClient, ILogger<SlTransportClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<SlDeparturesResponse?> GetDeparturesAsync(int siteId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"sites/{siteId}/departures", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogWarning("SL Transport API returned {StatusCode} for site {SiteId}", response.StatusCode, siteId);
            return null;
        }

        return await response.Content.ReadFromJsonAsync<SlDeparturesResponse>(cancellationToken);
    }
}
