# Slice 07b: Frontend SignalR Wiring

## Goal

Connect the frontend dashboard to the ASP.NET Core SignalR Hub and display live network summary data on the overview page.

## Why This Slice Exists

The dashboard shell from slice 06 uses fixture data. This slice replaces the fixtures with real server-pushed updates from the SignalR Hub set up in slice 07a.

## Depends On

- [../main/plan.md](../main/plan.md)
- [07a-signalr-hub-backend.md](07a-signalr-hub-backend.md)

## In Scope

- create `frontend/src/hub/dashboardHub.ts` — builds and exports a configured `HubConnection` pointed at the backend hub URL
- create `frontend/src/hooks/useNetworkSummary.ts` — React hook that starts the connection, listens for `ReceiveSummary` events, and exposes `{ summary, connected }` state
- replace hardcoded fixture values in `frontend/src/pages/Overview.tsx` with values from `useNetworkSummary`
- show a connection status indicator (connected / connecting / disconnected) in the UI
- handle reconnection automatically using the SignalR client's built-in retry policy

## Out Of Scope

- wiring other hub events (delayed routes, disruptions)
- authentication
- environment variable management beyond a simple base URL constant

## Likely Files

- frontend/src/hub/dashboardHub.ts
- frontend/src/hooks/useNetworkSummary.ts
- frontend/src/pages/Overview.tsx (update fixture values → hook values)
- frontend/src/components/ConnectionStatus.tsx (small status badge)

## Hub Contract (matches 07a)

The frontend listens for:

```
ReceiveSummary(summary: NetworkSummary)
```

Where `NetworkSummary` has at minimum:

```ts
interface NetworkSummary {
  totalDepartures: number;
  onTimeCount: number;
  delayedCount: number;
  onTimePercent: number;
}
```

Define this type in `frontend/src/types/NetworkSummary.ts`.

## Implementation Notes

Build the hub connection with `withAutomaticReconnect()`.
Start the connection in a `useEffect` and stop it on cleanup.
Keep the hub URL as a constant at the top of `dashboardHub.ts` — do not hardcode it inline across files.

## Verification

- `npm run dev` starts the frontend without errors
- with the backend running, the overview page shows live summary values that update every ~15 seconds
- the connection status indicator reflects the real hub state
- stopping the backend causes the indicator to show disconnected; restarting reconnects automatically

## Done When

- the overview page shows live backend data via SignalR with visible connection state

## Suggested Commit Message

feat: wire frontend to SignalR hub for live summary updates
