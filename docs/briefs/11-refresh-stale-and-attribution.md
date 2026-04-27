# Slice 11: Refresh, Stale States, And Attribution

## Goal

Make the dashboard safer and more honest by showing data freshness, handling stale data, and adding required source attribution.

## Why This Slice Exists

An operations dashboard can mislead users if it looks live when data is stale.

## Depends On

- [../main/plan.md](../main/plan.md)
- [10-suggestions-engine.md](10-suggestions-engine.md)

## In Scope

- show last updated time or refresh status
- handle stale or unavailable data clearly
- add attribution required by the chosen data source

## Out Of Scope

- authentication
- deployment platform setup
- alerting infrastructure

## Likely Files

- dashboard components that show freshness state
- shared UI status components if needed
- footer or attribution surface

## Implementation Notes

This slice is about trust.

Users should never have to guess whether the dashboard is showing fresh information.

## Verification

- the UI shows freshness information in a visible way
- stale data messaging appears under a forced or simulated stale condition
- attribution is present where required

## Done When

- the dashboard communicates freshness and source responsibility clearly

## Suggested Commit Message

feat: add refresh states and attribution