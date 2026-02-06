# Performer Identifier

A cross-platform desktop application for privacy-conscious video analysis and face recognition. Runs entirely offline using local ONNX ML models.

## Features

- **Face Detection**: RetinaFace/SCRFD models for accurate face detection in video frames
- **Face Recognition**: ArcFace embeddings with cosine similarity matching
- **Performer Library**: SQLite-backed database for enrolling and managing known performers
- **GPU Acceleration**: DirectML on Windows, CPU fallback on other platforms
- **Cross-Platform**: Built with Avalonia UI for Windows, macOS, and Linux
- **Privacy-First**: All processing runs locally; no data leaves the device
- **JSON Export**: Export analysis results for further processing

## Technology Stack

- **Language**: C# / .NET 10
- **UI**: Avalonia UI v11+
- **ML**: ONNX Runtime v1.17+ (DirectML on Windows)
- **Database**: SQLite + Entity Framework Core
- **Video**: FFmpeg (external CLI)
- **Architecture**: Clean Architecture (Core / Infrastructure / Presentation)

## Project Structure

```
PerformerIdentifier.slnx
├── src/
│   ├── PerformerIdentifier.Core/          # Domain layer (interfaces, entities, services)
│   ├── PerformerIdentifier.Windows/       # Infrastructure (DirectML, FFmpeg)
│   └── PerformerIdentifier.App/           # Avalonia UI application
└── tests/
    ├── PerformerIdentifier.Tests/         # Unit tests
    └── PerformerIdentifier.IntegrationTests/
```

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [FFmpeg](https://ffmpeg.org/download.html) (must be on PATH)
- ONNX Models (see `plan_docs/03-Model-Acquisition-Guide.md`)

## Build & Run

```bash
# Restore dependencies
dotnet restore PerformerIdentifier.slnx

# Build
dotnet build PerformerIdentifier.slnx

# Run tests
dotnet test PerformerIdentifier.slnx

# Run the application
dotnet run --project src/PerformerIdentifier.App
```

## Documentation

- [Application Plan](https://github.com/nam20485/PerformerIdentifier-Docs-delta99-a/issues/2)
- [Tech Stack](plan_docs/tech-stack.md)
- [Architecture](plan_docs/architecture.md)
- [Repository Summary](.ai-repository-summary.md)
- [Development Plan](plan_docs/01-Development-Plan.md)
- [Model Acquisition Guide](plan_docs/03-Model-Acquisition-Guide.md)

## License

See [LICENSE.md](LICENSE.md) for details.
