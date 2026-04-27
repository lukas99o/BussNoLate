# Slice 08: Delayed Routes View

## Goal

Add a delayed routes table and a first route-level drilldown surface.

## Why This Slice Exists

Operators need to move from a high-level summary into specific problem routes.

## Depends On

- [../main/plan.md](../main/plan.md)
- [07-summary-integration.md](07-summary-integration.md)

## In Scope

- expose backend data for delayed routes
- render a sortable or at least clearly ranked delayed routes view
- add a basic route detail panel, drawer, or page

## Out Of Scope

- disruptions panel
- suggestions engine
- network-wide filters beyond what is necessary for the view

## Likely Files

- frontend/src/components/RouteDelayTable.tsx
- backend/src/BussNoLate.Api/Endpoints/DelayedRoutesEndpoints.cs or Controllers/DelayedRoutesController.cs
- route detail related UI files if needed

## Implementation Notes

Keep the first route detail view simple.

It only needs enough detail to support operator triage.

## Verification

- delayed routes render in the UI from backend data
- one route can be opened or expanded for more detail

## Done When

- operators can move from network summary to route-level inspection

## Suggested Commit Message

feat: add delayed routes view