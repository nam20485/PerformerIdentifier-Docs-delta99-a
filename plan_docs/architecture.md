# Architecture - Performer Identifier

## Architectural Style

**Clean Architecture** (Onion/Hexagonal) with strict Dependency Rule: source code dependencies flow inward toward the core domain.

## Layer Diagram

```
┌─────────────────────────────────────────────┐
│  Presentation Layer (Avalonia UI)            │
│  ├── Views (AXAML windows/controls)         │
│  ├── ViewModels (MVVM state/commands)       │
│  └── DI Composition Root                    │
├─────────────────────────────────────────────┤
│  Infrastructure Layer                        │
│  ├── PerformerIdentifier.Windows            │
│  │   ├── DirectML inference adapter         │
│  │   └── FFmpeg frame extraction            │
│  └── (Future: macOS/Linux adapters)         │
├─────────────────────────────────────────────┤
│  Core/Domain Layer                           │
│  ├── Interfaces (IFaceDetectionService,     │
│  │   IVideoFrameExtractor, IPerformerRepo)  │
│  ├── Entities (Performer, DetectionResult)  │
│  ├── Services (VideoProcessorService)       │
│  └── Data (PerformerDatabase context)       │
└─────────────────────────────────────────────┘
```

## Project Structure

```
PerformerIdentifier.sln
├── src/
│   ├── PerformerIdentifier.Core/          # Domain layer (zero UI deps)
│   │   ├── Interfaces/                    # Service contracts
│   │   ├── Entities/                      # Domain models
│   │   ├── Services/                      # Business logic
│   │   └── Data/                          # Database context
│   │
│   ├── PerformerIdentifier.Windows/       # Infrastructure layer
│   │   ├── Services/                      # DirectML + FFmpeg implementations
│   │   └── Imaging/                       # Tensor conversion
│   │
│   └── PerformerIdentifier.App/           # Avalonia UI layer
│       ├── Views/                         # AXAML windows/controls
│       ├── ViewModels/                    # MVVM logic
│       └── Assets/                        # Icons, styles
│
└── tests/
    ├── PerformerIdentifier.Tests/         # Unit tests
    └── PerformerIdentifier.IntegrationTests/  # Integration tests
```

## Key Design Patterns

### Adapter Pattern (Hardware Abstraction)
`IInferenceEngine` defines a pure contract for inference. Concrete implementations adapt to:
- **Windows**: DirectML GPU acceleration via ONNX Runtime
- **Cross-platform**: CPU execution provider (AVX/AVX512)
- **macOS (future)**: CoreML Neural Engine

### Strategy Pattern
Platform-specific services implement core interfaces, selected at runtime based on `RuntimeInformation`.

### Repository Pattern
`IPerformerRepository` abstracts SQLite data access. `PerformerDatabase` (EF Core) provides the concrete implementation.

### MVVM Pattern
- **Model**: Domain entities and services from Core
- **ViewModel**: UI state, commands, and data binding
- **View**: Avalonia AXAML markup with data binding

## Data Flow

```
Video File → FFmpeg (frame extraction)
  → IFaceDetectionService (ONNX: detect faces)
    → ArcFace (ONNX: generate 512-dim embedding)
      → Cosine Similarity matching against performer DB
        → UI overlay (bounding boxes + labels)
```

## Threading Model

- UI thread: Avalonia dispatcher for rendering
- Background threads: All inference and I/O via Task.Run
- Cancellation: CancellationTokenSource for user-initiated stops

## Key Interfaces

| Interface | Purpose |
|-----------|---------|
| IFaceDetectionService | Face detection + recognition pipeline |
| IVideoFrameExtractor | Frame extraction from video files |
| IPerformerRepository | CRUD for performer embeddings |
| IInferenceEngine | Abstract ONNX inference execution |

## Database Schema (SQLite)

- **Performers**: Id, Name, Embedding (byte[]), CreatedAt, UpdatedAt
- **DetectionResults**: Id, VideoFile, Timestamp, PerformerId, Confidence, BoundingBox
