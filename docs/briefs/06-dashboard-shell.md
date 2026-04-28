# Slice 06: Dashboard Shell

## Goal

Scaffold the React frontend and build the first operator dashboard layout using hardcoded fixture data.

## Why This Slice Exists

The project needs a visible product surface early so later work can wire into a stable layout instead of inventing UI structure ad hoc.

## Depends On

- [../main/plan.md](../main/plan.md)
- [05-network-summary-metrics.md](05-network-summary-metrics.md)

## Frontend Stack (locked)

- React 19 + TypeScript
- Tailwind CSS v4
- Vite
- React Router v6
- @microsoft/signalr (installed now, wired in 07b)

## Scaffold Command

Run from the repo root:

```
npm create vite@latest frontend -- --template react-ts
cd frontend
npm install
npm install -D tailwindcss @tailwindcss/vite
npm install react-router-dom
npm install @microsoft/signalr
```

Add the Tailwind Vite plugin to `frontend/vite.config.ts` and import Tailwind in `frontend/src/index.css`.

## In Scope

- scaffold the Vite + React + TypeScript project under frontend/
- configure Tailwind CSS
- set up React Router with four route stubs: /, /routes, /disruptions, /suggestions
- build the network overview page with hardcoded fixture summary cards
- establish the visual hierarchy for quick operational scanning

## Out Of Scope

- live backend or SignalR wiring (that is 07a and 07b)
- route drilldown table content
- disruptions panel content
- suggestions panel content

## Likely Files

- frontend/index.html
- frontend/vite.config.ts
- frontend/src/main.tsx
- frontend/src/App.tsx
- frontend/src/index.css
- frontend/src/pages/Overview.tsx
- frontend/src/pages/Routes.tsx
- frontend/src/pages/Disruptions.tsx
- frontend/src/pages/Suggestions.tsx
- frontend/src/components/layout/AppShell.tsx
- frontend/src/components/NetworkSummaryCard.tsx

## Implementation Notes

Optimize for clarity first.

The overview page should immediately communicate whether the network looks healthy or stressed.
Use hardcoded fixture values for total departures, on-time percentage, and delayed count.
Keep stub pages for /routes, /disruptions, and /suggestions minimal — a heading is enough.

The AppShell should provide a top nav with links to all four routes.

## Verification

- `npm run dev` starts the frontend without errors
- navigating to / shows the network overview with fixture summary cards
- navigating to /routes, /disruptions, /suggestions shows stub pages
- the layout works on a typical desktop viewport

## Done When

- there is a stable visual shell with fixture data, ready to receive SignalR updates in 07b

## Suggested Commit Message

feat: scaffold frontend and add dashboard shell