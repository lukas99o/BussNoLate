# Slice 12: Deployment And Observability

## Goal

Prepare the app to run outside local development with basic health, logging, and deployment readiness.

## Why This Slice Exists

An app that only works on one machine is still a prototype.

This slice adds the minimum production-minded scaffolding needed before wider use.

## Depends On

- [../main/plan.md](../main/plan.md)
- [11-refresh-stale-and-attribution.md](11-refresh-stale-and-attribution.md)

## In Scope

- production-ready environment variable notes
- health checks suitable for hosting
- basic logging around upstream failures
- deployment notes for the chosen host

## Out Of Scope

- full observability platform integration
- enterprise auth
- autoscaling strategy

## Likely Files

- hosting config files if required by the chosen platform
- backend logging helpers if needed
- README.md or deployment notes
- backend health route updates if necessary

## Implementation Notes

Keep this slice practical.

Add the minimum deployment and diagnostics layer that makes the app supportable.

## Verification

- the app can be configured for a hosted environment
- health checks still respond correctly
- upstream failure paths leave useful logs or diagnostics

## Done When

- the project has a credible path from local development to a hosted environment

## Suggested Commit Message

chore: add deployment and observability basics