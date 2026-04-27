# Slice 02: Environment And Server Shape

## Goal

Add the first server-side structure for configuration and a simple internal health endpoint.

## Why This Slice Exists

Before touching transit data, the project needs a safe place for environment variables and a minimal server-side surface that later slices can extend.

## Depends On

- [../main/plan.md](../main/plan.md)
- [01-project-bootstrap.md](01-project-bootstrap.md)

## In Scope

- add strongly typed .NET configuration binding for required runtime values
- add one lightweight health route
- document the local environment variables or user-secrets needed for later work

## Out Of Scope

- real Trafiklab or SL calls
- caching
- normalization logic
- frontend data wiring

## Likely Files

- backend/src/BussNoLate.Api/Configuration/TrafiklabOptions.cs
- backend/src/BussNoLate.Api/Program.cs
- backend/src/BussNoLate.Api/Endpoints/HealthEndpoints.cs or Controllers/HealthController.cs
- README.md or a short setup note if required by the new env flow

## Implementation Notes

The health endpoint should be boring and stable.

The configuration binding should fail clearly if a required value is missing once a value becomes mandatory.

Do not overbuild a configuration system yet.

## Verification

- the backend still starts with the new configuration code in place
- the health endpoint responds successfully
- the documented configuration is enough for a contributor to understand the required runtime keys

## Done When

- there is a clear place for runtime config in the backend
- there is at least one internal backend route working

## Suggested Commit Message

feat: add env config and health endpoint