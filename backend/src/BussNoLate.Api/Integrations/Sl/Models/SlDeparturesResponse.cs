using System.Text.Json.Serialization;

namespace BussNoLate.Api.Integrations.Sl.Models;

public sealed class SlDeparturesResponse
{
    [JsonPropertyName("departures")]
    public List<SlDeparture> Departures { get; set; } = [];
}
