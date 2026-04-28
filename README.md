# BussNoLate

A web app for Stockholm bus operators to monitor punctuality across the network in near real time.

See [docs/main/plan.md](docs/main/plan.md) for architecture and roadmap.

## Local Setup

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Run the API

```sh
cd backend
dotnet run --project src/BussNoLate.Api
```

The API starts on `http://localhost:5075`. Verify it is running:

```sh
curl http://localhost:5075/health
# {"status":"ok"}
```

### Configuration

Runtime secrets are stored with `dotnet user-secrets` and are never committed.

From `backend/src/BussNoLate.Api`:

```sh
dotnet user-secrets init
dotnet user-secrets set "Trafiklab:ApiKey" "<your-key>"
```

The `Trafiklab:ApiKey` value is required from slice 03 onwards. You can obtain a key from [Trafiklab](https://www.trafiklab.se).
