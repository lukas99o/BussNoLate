using System.Text.Json.Serialization;

namespace BussNoLate.Api.Integrations.Sl.Models;

public sealed class SlDeparture
{
    [JsonPropertyName("direction")]
    public string Direction { get; set; } = string.Empty;

    [JsonPropertyName("display")]
    public string Display { get; set; } = string.Empty;

    [JsonPropertyName("scheduled")]
    public DateTimeOffset Scheduled { get; set; }

    [JsonPropertyName("expected")]
    public DateTimeOffset? Expected { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; } = string.Empty;

    [JsonPropertyName("line")]
    public SlLine Line { get; set; } = new();

    [JsonPropertyName("stop_point")]
    public SlStopPoint StopPoint { get; set; } = new();
}
