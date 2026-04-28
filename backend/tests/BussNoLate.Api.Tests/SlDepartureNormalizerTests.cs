using BussNoLate.Api.Domain.Normalization;
using BussNoLate.Api.Domain.Transport;
using BussNoLate.Api.Integrations.Sl.Models;

namespace BussNoLate.Api.Tests;

public class SlDepartureNormalizerTests
{
    private static SlDeparture BuildRaw(
        string state,
        DateTimeOffset scheduled,
        DateTimeOffset? expected = null,
        string designation = "1",
        string lineName = "Line 1",
        string transportMode = "BUS",
        string direction = "North",
        string stopPointName = "Main Stop") => new()
    {
        State = state,
        Scheduled = scheduled,
        Expected = expected,
        Direction = direction,
        Line = new SlLine { Designation = designation, Name = lineName, TransportMode = transportMode },
        StopPoint = new SlStopPoint { Name = stopPointName }
    };

    [Fact]
    public void OnTime_departure_maps_status_and_null_delay()
    {
        var scheduled = DateTimeOffset.UtcNow;
        var raw = BuildRaw("OnTime", scheduled);

        var result = SlDepartureNormalizer.Normalize(raw);

        Assert.Equal(DepartureStatus.OnTime, result.Status);
        Assert.Null(result.DelaySeconds);
    }

    [Fact]
    public void Delayed_departure_maps_status_and_positive_delay()
    {
        var scheduled = DateTimeOffset.UtcNow;
        var expected = scheduled.AddMinutes(3);
        var raw = BuildRaw("Delayed", scheduled, expected);

        var result = SlDepartureNormalizer.Normalize(raw);

        Assert.Equal(DepartureStatus.Delayed, result.Status);
        Assert.Equal(180, result.DelaySeconds);
    }

    [Fact]
    public void Cancelled_departure_maps_status()
    {
        var raw = BuildRaw("Cancelled", DateTimeOffset.UtcNow);

        var result = SlDepartureNormalizer.Normalize(raw);

        Assert.Equal(DepartureStatus.Cancelled, result.Status);
    }

    [Fact]
    public void Unknown_state_string_maps_to_Unknown()
    {
        var raw = BuildRaw("something_unexpected", DateTimeOffset.UtcNow);

        var result = SlDepartureNormalizer.Normalize(raw);

        Assert.Equal(DepartureStatus.Unknown, result.Status);
    }

    [Fact]
    public void State_matching_is_case_insensitive()
    {
        var raw = BuildRaw("ONTIME", DateTimeOffset.UtcNow);

        var result = SlDepartureNormalizer.Normalize(raw);

        Assert.Equal(DepartureStatus.OnTime, result.Status);
    }

    [Fact]
    public void Domain_fields_map_correctly_from_sl_model()
    {
        var scheduled = new DateTimeOffset(2026, 4, 28, 10, 0, 0, TimeSpan.Zero);
        var expected = scheduled.AddSeconds(60);
        var raw = BuildRaw(
            state: "Delayed",
            scheduled: scheduled,
            expected: expected,
            designation: "74",
            lineName: "Lidingöbanan",
            transportMode: "TRAM",
            direction: "Centrum",
            stopPointName: "Ropsten");

        var result = SlDepartureNormalizer.Normalize(raw);

        Assert.Equal("74", result.LineDesignation);
        Assert.Equal("Lidingöbanan", result.LineName);
        Assert.Equal("TRAM", result.TransportMode);
        Assert.Equal("Centrum", result.Direction);
        Assert.Equal("Ropsten", result.StopPointName);
        Assert.Equal(scheduled, result.Scheduled);
        Assert.Equal(expected, result.Expected);
        Assert.Equal(60, result.DelaySeconds);
    }
}
