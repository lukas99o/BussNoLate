interface NetworkSummaryCardProps {
  label: string
  value: string | number
  subtext?: string
  highlight?: 'ok' | 'warn' | 'critical' | 'neutral'
}

const highlightClasses: Record<string, string> = {
  ok: 'border-green-600 bg-green-950',
  warn: 'border-yellow-500 bg-yellow-950',
  critical: 'border-red-600 bg-red-950',
  neutral: 'border-gray-700 bg-gray-900',
}

export default function NetworkSummaryCard({
  label,
  value,
  subtext,
  highlight = 'neutral',
}: NetworkSummaryCardProps) {
  return (
    <div className={`rounded-lg border p-5 ${highlightClasses[highlight]}`}>
      <p className="text-xs font-medium uppercase tracking-wider text-gray-400 mb-1">{label}</p>
      <p className="text-3xl font-bold text-white">{value}</p>
      {subtext && <p className="text-sm text-gray-400 mt-1">{subtext}</p>}
    </div>
  )
}
