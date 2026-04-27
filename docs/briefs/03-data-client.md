# Slice 03: Trafiklab Or SL Data Client

## Goal

Create the first data client that can fetch one live or fixture-backed Stockholm transit dataset.

## Why This Slice Exists

The app cannot become useful until it can read transit data in a controlled way.

This slice isolates upstream fetching before normalization and UI work begin.

## Depends On

- [../main/plan.md](../main/plan.md)
- [02-env-and-server-shape.md](02-env-and-server-shape.md)

## In Scope

- choose the first upstream endpoint to integrate
- add a dedicated client module for that endpoint
- parse the raw response into typed upstream models
- support fixtures if live credentials are not ready yet

## Out Of Scope

- internal domain normalization
- delay metrics
- dashboard rendering
- operator suggestions

## Likely Files

- backend/src/BussNoLate.Api/Integrations/Trafiklab/TrafiklabClient.cs
- backend/src/BussNoLate.Api/Integrations/Trafiklab/Models/*.cs
- backend/src/BussNoLate.Api/Integrations/Trafiklab/Fixtures/* if fixtures are used
- one temporary debug route or small test helper if needed

## Implementation Notes

Keep the client narrowly focused on one useful upstream call.

Do not combine fetching, normalization, and metrics into one module.

If live access is blocked, land the same slice using fixtures and keep the client interface stable.

## Verification

- one live or fixture-backed fetch succeeds
- the raw response is parsed into stable types
- failures are surfaced clearly enough to debug configuration issues

## Done When

- the project has a reusable upstream client that returns typed data for one selected feed

## Suggested Commit Message

feat: add stockholm transit data client