import NetworkSummaryCard from '../components/NetworkSummaryCard'

// Fixture data — replaced with live SignalR data in slice 07b
const FIXTURE = {
  totalDepartures: 412,
  onTimeCount: 334,
  delayedCount: 78,
  onTimePercent: 81,
}

function deriveHighlight(onTimePercent: number): 'ok' | 'warn' | 'critical' {
  if (onTimePercent >= 90) return 'ok'
  if (onTimePercent >= 75) return 'warn'
  return 'critical'
}

export default function Overview() {
  const { totalDepartures, onTimeCount, delayedCount, onTimePercent } = FIXTURE
  const highlight = deriveHighlight(onTimePercent)

  return (
    <div>
      <h1 className="text-xl font-semibold text-white mb-5">Network Overview</h1>
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-4">
        <NetworkSummaryCard
          label="Total Departures"
          value={totalDepartures}
          subtext="in the last fetch"
        />
        <NetworkSummaryCard
          label="On Time"
          value={`${onTimePercent}%`}
          subtext={`${onTimeCount} departures`}
          highlight={highlight}
        />
        <NetworkSummaryCard
          label="Delayed"
          value={delayedCount}
          subtext="departures late"
          highlight={delayedCount > 50 ? 'critical' : delayedCount > 20 ? 'warn' : 'ok'}
        />
        <NetworkSummaryCard
          label="Network Status"
          value={highlight === 'ok' ? 'Healthy' : highlight === 'warn' ? 'Under Pressure' : 'Stressed'}
          highlight={highlight}
        />
      </div>
    </div>
  )
}
