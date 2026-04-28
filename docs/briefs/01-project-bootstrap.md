# Slice 01: Repository And Backend Bootstrap

## Goal

Create the initial repo shape and .NET backend skeleton so the backend restores, starts locally, and exposes a minimal root response.

## Why This Slice Exists

Nothing else should be built until the repo has a stable project shape.

This slice should give the project a predictable structure without pulling in real transit logic yet.

## Depends On

- [../main/plan.md](../main/plan.md)

## In Scope

- initialize the .NET solution and backend project structure
- create the base ASP.NET Core Web API structure
- add the minimum local run workflow for the backend
- add a minimal root endpoint that confirms the backend boots
- add a .gitignore if missing
- add a dotnet xUnit test project 

## Out Of Scope

- environment variable parsing
- external API integration
- frontend scaffolding beyond a reserved folder if desired
- tests beyond what the scaffold requires

## Likely Files

- .gitignore
- backend/BussNoLate.sln
- backend/src/BussNoLate.Api/BussNoLate.Api.csproj
- backend/src/BussNoLate.Api/Program.cs
- backend/src/BussNoLate.Api/appsettings.json
- backend/src/BussNoLate.Api/appsettings.Development.json

## Implementation Notes

Keep the backend intentionally simple.

The only job of this slice is to prove the backend scaffold works and gives later slices a stable place to land.

Avoid adding placeholder business logic that will be thrown away immediately.

## Verification

- dotnet restore succeeds
- dotnet run succeeds for the backend project
- the minimal root response can be reached locally without errors

## Done When

- a contributor can clone the repo, restore the backend, run it, and confirm the service starts cleanly

## Suggested Commit Message

chore: bootstrap dotnet backend