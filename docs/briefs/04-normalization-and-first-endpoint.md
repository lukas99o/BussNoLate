# Slice 04: Normalization And First Endpoint

## Goal

Turn raw upstream transport data into internal models and expose the first app-facing endpoint.

## Why This Slice Exists

The rest of the app should depend on stable internal shapes, not directly on upstream API responses.

## Depends On

- [../main/plan.md](../main/plan.md)
- [03-data-client.md](03-data-client.md)

## In Scope

- define internal transport types
- normalize the first upstream dataset into those types
- create one app-facing endpoint that returns normalized data

## Out Of Scope

- dashboard layout work
- suggestion rules
- multiple endpoint families

## Likely Files

- backend/src/BussNoLate.Api/Domain/Transport/*.cs
- backend/src/BussNoLate.Api/Domain/Normalization/*.cs
- backend/src/BussNoLate.Api/Endpoints/NetworkSummaryEndpoints.cs or Controllers/NetworkSummaryController.cs

## Implementation Notes

Keep the first endpoint narrow.

It should return only the fields needed for the first network summary, not the entire universe of raw upstream fields.

## Verification

- the endpoint returns normalized data without leaking raw upstream structure
- the response shape is stable enough for frontend work to begin

## Done When

- frontend slices can depend on one backend endpoint instead of raw upstream clients

## Suggested Commit Message

feat: add normalized network summary endpoint