# Slice 05: Network Summary Metrics

## Goal

Add the first delay calculations and automated tests for the core punctuality logic.

## Why This Slice Exists

The app needs simple, trustworthy metrics before the UI starts presenting operational conclusions.

## Depends On

- [../main/plan.md](../main/plan.md)
- [04-normalization-and-first-endpoint.md](04-normalization-and-first-endpoint.md)

## In Scope

- define the first lateness thresholds
- calculate summary counts and status buckets
- add xUnit tests for the delay logic using the test project in backend/tests/BussNoLate.Api.Tests/

## Out Of Scope

- advanced analytics
- prediction models
- suggestion rules

## Likely Files

- backend/src/BussNoLate.Api/Domain/Metrics/*.cs
- backend/tests/BussNoLate.Api.Tests/Domain/MetricsTests.cs

## Implementation Notes

Prefer simple, explainable calculations.

If the threshold is uncertain, make it configurable later rather than overcomplicating this slice.

## Verification

- unit tests pass for the initial lateness calculations
- the summary endpoint can use the new metrics without breaking its response shape

## Done When

- the project has tested logic for the first operator-facing punctuality summary

## Suggested Commit Message

feat: add network summary metrics