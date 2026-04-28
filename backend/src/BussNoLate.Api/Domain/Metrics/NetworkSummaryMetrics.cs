namespace BussNoLate.Api.Domain.Metrics;

public sealed record NetworkSummaryMetrics
{
    public int Total { get; init; }
    public int OnTime { get; init; }
    public int MinorDelay { get; init; }
    public int MajorDelay { get; init; }
    public int Cancelled { get; init; }
    public int Unknown { get; init; }
    public double DelayRate => Total == 0 ? 0 : (MinorDelay + MajorDelay) / (double)Total;
}
