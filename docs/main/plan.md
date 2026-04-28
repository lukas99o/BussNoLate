# Stockholm Bus Punctuality App

Status: Planning baseline
Last updated: 2026-04-27

## Purpose

This document is the repo-level source of truth for the project.

It explains what we are building, what we are not building, how work should be split into small slices, and how a new agent window should pick up the next task without loading the entire history of the project.

## Product Summary

We are building a web app for Stockholm bus operators.

The app should help operators spot where buses are running late, understand which routes or stop areas are under pressure, and see simple rule-based suggestions about where to focus attention first.

This is not a passenger trip planner.

## Problem Statement

Bus operators need a faster way to see punctuality problems across the network.

Live transit data exists, but the raw feeds are too technical and fragmented for quick operational use. The app should turn that data into a simple operational dashboard.

## MVP Goal

Deliver a working operator dashboard for Stockholm buses that:

- shows network-wide lateness in near real time
- highlights delayed routes and problem areas
- surfaces active disruptions that may explain delays
- provides transparent rule-based suggestions

## Primary User

Primary user: Stockholm bus operators and dispatch-focused staff.

## In Scope

- Stockholm bus network only
- web app only
- operator dashboard only
- real-time or near-real-time monitoring
- rule-based suggestions with visible reasoning
- small, frequent commits during implementation

## Out Of Scope For MVP

- passenger journey planning
- native mobile apps
- machine learning delay prediction
- automatic dispatch control
- network optimization or schedule redesign
- multi-region support outside Stockholm

## Technical Direction

Default implementation direction:

- split architecture with a .NET backend and a separate web frontend
- ASP.NET Core Web API backend for Trafiklab or SL integration, normalization, metrics, and suggestions
- frontend consumes backend endpoints instead of owning transit logic directly
- keep backend contracts framework-agnostic so the frontend can evolve independently
- fixture-first development when API setup would otherwise block progress
- xUnit is the test framework for all backend tests, located in backend/tests/BussNoLate.Api.Tests/

Reason for this direction:

- matches the explicit .NET backend decision
- clear separation between operational data logic and UI
- smaller diffs per slice
- easier local setup
- better fit for short agent windows and small commits

If the stack changes later, update this document before implementation continues.

## Data Direction

Primary data path:

- start with Trafiklab or SL live transport data
- add deviations or disruption data once the first live summary works
- normalize all upstream data into backend-owned internal models before exposing it to the UI

Historical datasets and prediction work are follow-up phases, not part of the MVP.

## Repo Shape

Default repo layout:

- backend/ for the ASP.NET Core API
- frontend/ for the operator dashboard client
- docs/ for the master plan and execution briefs

If the frontend stack is not finalized yet, keep the backend slices fully specific and keep frontend-facing briefs framework-light until the frontend scaffold is chosen.

## Quality Bar

Each slice should produce one clear result that can be checked quickly.

Examples:

- the app boots locally
- a health endpoint responds
- one live dataset is fetched
- one normalized endpoint returns stable data
- one dashboard panel renders correctly
- one rule test passes

Do not bundle multiple large concerns into one commit.

## Working Model

We will build the app in small vertical slices.

Each slice should:

- focus on one outcome
- touch a small number of files where possible
- include a clear verification step
- end with one small commit

## How To Use These Docs

When starting a new agent window:

1. Read this plan.
2. Read only the next relevant brief from ../briefs.
3. Load only the files needed for that brief.
4. Implement the slice.
5. Verify the slice.
6. Commit the slice.

The plan should stay fairly stable.

The briefs can be updated as implementation reality changes.

## Roadmap

1. [01-project-bootstrap.md](../briefs/01-project-bootstrap.md)
2. [02-env-and-server-shape.md](../briefs/02-env-and-server-shape.md)
3. [03-data-client.md](../briefs/03-data-client.md)
4. [04-normalization-and-first-endpoint.md](../briefs/04-normalization-and-first-endpoint.md)
5. [05-network-summary-metrics.md](../briefs/05-network-summary-metrics.md)
6. [06-dashboard-shell.md](../briefs/06-dashboard-shell.md)
7. [07-summary-integration.md](../briefs/07-summary-integration.md)
8. [08-delayed-routes-view.md](../briefs/08-delayed-routes-view.md)
9. [09-disruptions-panel.md](../briefs/09-disruptions-panel.md)
10. [10-suggestions-engine.md](../briefs/10-suggestions-engine.md)
11. [11-refresh-stale-and-attribution.md](../briefs/11-refresh-stale-and-attribution.md)
12. [12-deployment-and-observability.md](../briefs/12-deployment-and-observability.md)

## Slice Definition Of Done

A slice is done when:

- the scope in the brief has been implemented
- the out-of-scope items were not pulled in early
- the verification step passes
- the result is understandable in isolation
- the change is small enough for one commit

## Change Rules

Update this plan when:

- project scope changes
- the chosen stack changes
- the order of major slices changes
- the product target changes

Update a brief when:

- implementation details change
- expected files change materially
- the verification method changes
- the slice needs to be split further

## Git Strategy

The first commit can be the planning baseline only.

After that, each implementation brief should ideally map to one commit. If a slice becomes too large, split it into smaller briefs before coding.

## Notes For Future Agents

Do not reopen broad architectural debates during a slice unless the current brief is blocked by a real constraint.

Prefer progress through small verified slices over large speculative builds.