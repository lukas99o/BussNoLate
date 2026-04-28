# Slice 07a: SignalR Hub — Backend Setup

## Goal

Add an ASP.NET Core SignalR Hub to the backend that pushes network summary metrics to connected clients on a timer.

## Why This Slice Exists

The frontend needs server-pushed data instead of client-side polling. This slice wires the existing summary metrics into a SignalR Hub so the backend controls the update cadence.

## Depends On

- [../main/plan.md](../main/plan.md)
- [06-dashboard-shell.md](06-dashboard-shell.md)

## In Scope

- add `Microsoft.AspNetCore.SignalR` (already included in ASP.NET Core, no extra package needed)
- create `Hubs/DashboardHub.cs` — a SignalR Hub class
- register SignalR in `Program.cs` (`builder.Services.AddSignalR()` and `app.MapHub<DashboardHub>("/hubs/dashboard")`)
- add a background service (`Services/MetricsBroadcastService.cs`) that fetches the current network summary from the existing metrics logic and broadcasts it to all hub clients every 15 seconds
- configure CORS in `Program.cs` to allow the frontend origin (`http://localhost:5173`)

## Out Of Scope

- frontend SignalR client (that is 07b)
- authentication or per-client filtering
- other hub events (delayed routes, disruptions)

## Likely Files

- backend/src/BussNoLate.Api/Hubs/DashboardHub.cs
- backend/src/BussNoLate.Api/Services/MetricsBroadcastService.cs
- backend/src/BussNoLate.Api/Program.cs (SignalR registration + CORS)

## Hub Contract

The hub broadcasts one method to clients:

```
ReceiveSummary(NetworkSummary summary)
```

Where `NetworkSummary` is an existing or new record containing the metrics already computed in slice 05.

## Implementation Notes

The background service should use `IHubContext<DashboardHub>` to push to all clients.
Use `IHostedService` or `BackgroundService` for the timer loop.
Do not re-implement summary computation — call the existing metrics logic.

## Verification

- the backend starts without errors
- connecting to `ws://localhost:<port>/hubs/dashboard` with a SignalR test client (or browser console) receives `ReceiveSummary` messages roughly every 15 seconds

## Done When

- the hub is registered, the background service is broadcasting, and the backend compiles and runs

## Suggested Commit Message

feat: add SignalR hub and metrics broadcast service