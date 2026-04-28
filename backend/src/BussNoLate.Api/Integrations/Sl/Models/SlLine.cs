using System.Text.Json.Serialization;

namespace BussNoLate.Api.Integrations.Sl.Models;

public sealed class SlLine
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("designation")]
    public string Designation { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("transport_mode")]
    public string TransportMode { get; set; } = string.Empty;
}
