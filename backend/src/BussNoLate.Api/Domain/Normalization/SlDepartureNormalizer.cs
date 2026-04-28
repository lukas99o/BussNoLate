using BussNoLate.Api.Domain.Transport;
using BussNoLate.Api.Integrations.Sl.Models;

namespace BussNoLate.Api.Domain.Normalization;

public static class SlDepartureNormalizer
{
    public static Departure Normalize(SlDeparture raw)
    {
        var delaySeconds = raw.Expected.HasValue
            ? (int?)(int)(raw.Expected.Value - raw.Scheduled).TotalSeconds
            : null;

        return new Departure
        {
            LineDesignation = raw.Line.Designation,
            LineName = raw.Line.Name,
            TransportMode = raw.Line.TransportMode,
            Direction = raw.Direction,
            StopPointName = raw.StopPoint.Name,
            Scheduled = raw.Scheduled,
            Expected = raw.Expected,
            DelaySeconds = delaySeconds,
            Status = ParseStatus(raw.State)
        };
    }

    private static DepartureStatus ParseStatus(string state) =>
        state.ToUpperInvariant() switch
        {
            "ONTIME" => DepartureStatus.OnTime,
            "DELAYED" => DepartureStatus.Delayed,
            "CANCELLED" => DepartureStatus.Cancelled,
            _ => DepartureStatus.Unknown
        };
}
