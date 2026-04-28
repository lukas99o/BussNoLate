using BussNoLate.Api.Domain.Metrics;
using BussNoLate.Api.Domain.Transport;

namespace BussNoLate.Api.Tests.Domain;

public class MetricsTests
{
    private static Departure BuildDeparture(
        DepartureStatus status,
        int? delaySeconds = null) => new()
    {
        LineDesignation = "1",
        LineName = "Line 1",
        TransportMode = "BUS",
        Direction = "North",
        StopPointName = "Main Stop",
        Scheduled = DateTimeOffset.UtcNow,
        Expected = delaySeconds.HasValue ? DateTimeOffset.UtcNow.AddSeconds(delaySeconds.Value) : null,
        DelaySeconds = delaySeconds,
        Status = status
    };

    [Fact]
    public void Empty_list_returns_all_zeros_and_zero_delay_rate()
    {
        var result = NetworkSummaryCalculator.Calculate([]);

        Assert.Equal(0, result.Total);
        Assert.Equal(0, result.OnTime);
        Assert.Equal(0, result.MinorDelay);
        Assert.Equal(0, result.MajorDelay);
        Assert.Equal(0, result.Cancelled);
        Assert.Equal(0, result.Unknown);
        Assert.Equal(0.0, result.DelayRate);
    }

    [Fact]
    public void All_on_time_returns_correct_counts_and_zero_delay_rate()
    {
        var departures = new[]
        {
            BuildDeparture(DepartureStatus.OnTime),
            BuildDeparture(DepartureStatus.OnTime),
            BuildDeparture(DepartureStatus.OnTime)
        };

        var result = NetworkSummaryCalculator.Calculate(departures);

        Assert.Equal(3, result.Total);
        Assert.Equal(3, result.OnTime);
        Assert.Equal(0, result.MinorDelay);
        Assert.Equal(0, result.MajorDelay);
        Assert.Equal(0.0, result.DelayRate);
    }

    [Fact]
    public void Delay_of_59_seconds_counts_as_on_time()
    {
        var result = NetworkSummaryCalculator.Calculate([BuildDeparture(DepartureStatus.Delayed, 59)]);

        Assert.Equal(1, result.OnTime);
        Assert.Equal(0, result.MinorDelay);
    }

    [Fact]
    public void Delay_of_60_seconds_counts_as_minor_delay()
    {
        var result = NetworkSummaryCalculator.Calculate([BuildDeparture(DepartureStatus.Delayed, 60)]);

        Assert.Equal(0, result.OnTime);
        Assert.Equal(1, result.MinorDelay);
    }

    [Fact]
    public void Delay_of_299_seconds_counts_as_minor_delay()
    {
        var result = NetworkSummaryCalculator.Calculate([BuildDeparture(DepartureStatus.Delayed, 299)]);

        Assert.Equal(1, result.MinorDelay);
        Assert.Equal(0, result.MajorDelay);
    }

    [Fact]
    public void Delay_of_300_seconds_counts_as_major_delay()
    {
        var result = NetworkSummaryCalculator.Calculate([BuildDeparture(DepartureStatus.Delayed, 300)]);

        Assert.Equal(0, result.MinorDelay);
        Assert.Equal(1, result.MajorDelay);
    }

    [Fact]
    public void Null_delay_counts_as_on_time()
    {
        var result = NetworkSummaryCalculator.Calculate([BuildDeparture(DepartureStatus.OnTime, null)]);

        Assert.Equal(1, result.OnTime);
        Assert.Equal(0, result.MinorDelay);
    }

    [Fact]
    public void Cancelled_departure_is_counted_in_cancelled_bucket()
    {
        var result = NetworkSummaryCalculator.Calculate([BuildDeparture(DepartureStatus.Cancelled)]);

        Assert.Equal(1, result.Total);
        Assert.Equal(1, result.Cancelled);
        Assert.Equal(0, result.OnTime);
    }

    [Fact]
    public void Unknown_departure_is_counted_in_unknown_bucket()
    {
        var result = NetworkSummaryCalculator.Calculate([BuildDeparture(DepartureStatus.Unknown)]);

        Assert.Equal(1, result.Total);
        Assert.Equal(1, result.Unknown);
        Assert.Equal(0, result.OnTime);
    }

    [Fact]
    public void Mixed_departures_produce_correct_counts_and_delay_rate()
    {
        var departures = new[]
        {
            BuildDeparture(DepartureStatus.OnTime),          // on time
            BuildDeparture(DepartureStatus.Delayed, 59),     // on time (below threshold)
            BuildDeparture(DepartureStatus.Delayed, 60),     // minor delay
            BuildDeparture(DepartureStatus.Delayed, 299),    // minor delay
            BuildDeparture(DepartureStatus.Delayed, 300),    // major delay
            BuildDeparture(DepartureStatus.Cancelled),       // cancelled
            BuildDeparture(DepartureStatus.Unknown)          // unknown
        };

        var result = NetworkSummaryCalculator.Calculate(departures);

        Assert.Equal(7, result.Total);
        Assert.Equal(2, result.OnTime);
        Assert.Equal(2, result.MinorDelay);
        Assert.Equal(1, result.MajorDelay);
        Assert.Equal(1, result.Cancelled);
        Assert.Equal(1, result.Unknown);
        Assert.Equal(3.0 / 7.0, result.DelayRate, precision: 10);
    }
}
