using System.Text.Json.Serialization;

namespace BussNoLate.Api.Integrations.Sl.Models;

public sealed class SlStopPoint
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
