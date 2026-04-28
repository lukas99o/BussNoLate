using BussNoLate.Api.Domain.Transport;

namespace BussNoLate.Api.Domain.Metrics;

public static class NetworkSummaryCalculator
{
    public static NetworkSummaryMetrics Calculate(IEnumerable<Departure> departures)
    {
        int onTime = 0, minorDelay = 0, majorDelay = 0, cancelled = 0, unknown = 0;

        foreach (var departure in departures)
        {
            switch (departure.Status)
            {
                case DepartureStatus.Cancelled:
                    cancelled++;
                    break;
                case DepartureStatus.Unknown:
                    unknown++;
                    break;
                default:
                    var delay = departure.DelaySeconds ?? 0;
                    if (delay >= LatencyThresholds.MajorDelaySeconds)
                        majorDelay++;
                    else if (delay >= LatencyThresholds.MinorDelaySeconds)
                        minorDelay++;
                    else
                        onTime++;
                    break;
            }
        }

        return new NetworkSummaryMetrics
        {
            Total = onTime + minorDelay + majorDelay + cancelled + unknown,
            OnTime = onTime,
            MinorDelay = minorDelay,
            MajorDelay = majorDelay,
            Cancelled = cancelled,
            Unknown = unknown
        };
    }
}
