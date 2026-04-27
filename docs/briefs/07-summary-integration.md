# Slice 07: Summary Integration

## Goal

Wire the dashboard summary view to the normalized backend summary endpoint.

## Why This Slice Exists

This is the point where the app starts behaving like a real monitoring tool instead of a static prototype.

## Depends On

- [../main/plan.md](../main/plan.md)
- [06-dashboard-shell.md](06-dashboard-shell.md)

## In Scope

- fetch summary data from the internal endpoint
- show live or fixture-backed summary values in the UI
- handle loading and error states for the summary block

## Out Of Scope

- route tables
- disruptions panel
- suggestion logic

## Likely Files

- frontend/src/App.tsx or frontend/src/pages/Dashboard.tsx
- frontend/src/components/NetworkOverview.tsx
- frontend/src/api/client.ts or similar helper files for data fetching

## Implementation Notes

Keep the integration boundary simple.

If polling is not ready yet, a single fetch on load is enough for this slice.

## Verification

- the dashboard summary renders using the real internal endpoint
- loading and basic failure states are visible and understandable

## Done When

- the top-level dashboard summary reflects backend data instead of mock values

## Suggested Commit Message

feat: wire dashboard summary to backend