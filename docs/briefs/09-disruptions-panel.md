# Slice 09: Disruptions Panel

## Goal

Surface active disruptions that may explain delay spikes.

## Why This Slice Exists

Without disruption context, the dashboard risks showing symptoms without any operational clues about the cause.

## Depends On

- [../main/plan.md](../main/plan.md)
- [08-delayed-routes-view.md](08-delayed-routes-view.md)

## In Scope

- add the first disruptions data path
- normalize disruption messages into internal models
- render a visible disruptions panel in the dashboard

## Out Of Scope

- suggestion rules based on disruptions
- advanced filtering or search

## Likely Files

- backend/src/BussNoLate.Api/Integrations/Trafiklab/DeviationsClient.cs or similar
- backend/src/BussNoLate.Api/Domain/Disruptions/*.cs if needed
- frontend/src/components/DisruptionsPanel.tsx
- an internal endpoint for disruptions if needed

## Implementation Notes

Favor readability over completeness.

The first panel should surface the most useful disruption details without becoming a wall of text.

## Verification

- disruptions render in the UI from normalized data
- the panel remains understandable even with several active items

## Done When

- the dashboard provides basic disruption context alongside lateness views

## Suggested Commit Message

feat: add disruptions panel