# Slice 06: Dashboard Shell

## Goal

Build the first operator dashboard layout using mocked or fixture-backed data.

## Why This Slice Exists

The project needs a visible product surface early so later work can wire into a stable layout instead of inventing UI structure ad hoc.

## Depends On

- [../main/plan.md](../main/plan.md)
- [05-network-summary-metrics.md](05-network-summary-metrics.md)

## In Scope

- create the first dashboard page layout
- add placeholder or mocked summary cards
- establish the visual hierarchy for quick operational scanning

## Out Of Scope

- live backend wiring
- route drilldown details
- disruptions panel
- suggestions panel

## Likely Files

- frontend/src/App.tsx or frontend/src/pages/Dashboard.tsx
- frontend/src/components/NetworkOverview.tsx
- frontend/src/components/layout/* if needed
- frontend styling files related to the dashboard shell

## Implementation Notes

Optimize for clarity first.

The dashboard should immediately communicate whether the network looks healthy or stressed.

## Verification

- the dashboard renders locally without backend integration
- the layout works on a typical desktop viewport and remains usable on smaller widths

## Done When

- there is a stable visual shell ready to receive live data

## Suggested Commit Message

feat: add dashboard shell