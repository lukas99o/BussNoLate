namespace BussNoLate.Api.Domain.Transport;

public sealed class Departure
{
    public string LineDesignation { get; init; } = string.Empty;
    public string LineName { get; init; } = string.Empty;
    public string TransportMode { get; init; } = string.Empty;
    public string Direction { get; init; } = string.Empty;
    public string StopPointName { get; init; } = string.Empty;
    public DateTimeOffset Scheduled { get; init; }
    public DateTimeOffset? Expected { get; init; }
    public int? DelaySeconds { get; init; }
    public DepartureStatus Status { get; init; }
}
