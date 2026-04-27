# Slice 10: Suggestions Engine

## Goal

Add the first rule-based operational suggestions and show the reasoning behind them.

## Why This Slice Exists

This is the slice that turns the dashboard from a passive monitor into an operational support tool.

## Depends On

- [../main/plan.md](../main/plan.md)
- [09-disruptions-panel.md](09-disruptions-panel.md)

## In Scope

- define a small set of deterministic suggestion rules
- attach the signals that triggered each suggestion
- render suggestions in a dedicated panel
- add tests for the rules if practical in the same slice

## Out Of Scope

- machine learning
- automated interventions
- deeply configurable rules engine

## Likely Files

- backend/src/BussNoLate.Api/Domain/Suggestions/*.cs
- backend/tests/BussNoLate.Api.Tests/Domain/SuggestionsTests.cs
- frontend/src/components/SuggestionPanel.tsx

## Implementation Notes

The suggestions should be auditable.

A user should be able to understand why a suggestion appeared without reading the source code.

## Verification

- the UI displays suggestions with supporting reasons
- the rules behave predictably for known input cases

## Done When

- operators can see a small set of explainable actions or focus areas based on current conditions

## Suggested Commit Message

feat: add rule-based suggestions