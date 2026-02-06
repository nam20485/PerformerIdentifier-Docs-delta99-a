# Technology Stack - Performer Identifier

## Language & Runtime

| Technology | Version | Purpose |
|-----------|---------|---------|
| C# | Latest (with .NET 10) | Primary language |
| .NET | 10.0 | Runtime and SDK |

## UI Framework

| Technology | Version | Purpose |
|-----------|---------|---------|
| Avalonia UI | 11.x+ | Cross-platform desktop UI framework |
| CommunityToolkit.Mvvm | Latest | MVVM pattern support (RelayCommand, ObservableProperty) |

**Note**: The original spec references WinUI 3. Per stakeholder direction, the project uses Avalonia UI v11+ for cross-platform support (Windows, macOS, Linux). The architecture and MVVM patterns remain the same.

## Machine Learning / AI

| Technology | Version | Purpose |
|-----------|---------|---------|
| ONNX Runtime | 1.17+ | ML inference engine |
| Microsoft.ML.OnnxRuntime.DirectML | 1.17+ | GPU acceleration on Windows |
| RetinaFace/SCRFD | - | Face detection ONNX model (640x640 input) |
| ArcFace | - | Face recognition ONNX model (112x112 input, 512-dim output) |

## Data & Storage

| Technology | Version | Purpose |
|-----------|---------|---------|
| SQLite | - | Local embedded database |
| Entity Framework Core | 8.0+ | ORM for SQLite (Microsoft.EntityFrameworkCore.Sqlite) |

## Media & Image Processing

| Technology | Version | Purpose |
|-----------|---------|---------|
| FFmpeg | Latest | Video frame extraction (external CLI) |
| SixLabors.ImageSharp | 3.1+ | Cross-platform image manipulation (crop, resize, normalize) |

## Testing

| Technology | Version | Purpose |
|-----------|---------|---------|
| xUnit | Latest | Unit and integration test framework |
| Moq | Latest | Mocking framework for dependency injection |
| coverlet | Latest | Code coverage collection |

## DevOps & CI/CD

| Technology | Version | Purpose |
|-----------|---------|---------|
| GitHub Actions | - | CI/CD pipeline |
| Docker | - | Future headless server containerization |
| TruffleHog | - | Secret scanning |

## Key NuGet Packages

1. **Avalonia** - Cross-platform UI framework
2. **Avalonia.Desktop** - Desktop platform support
3. **Avalonia.Themes.Fluent** - Modern Fluent design theme
4. **Microsoft.ML.OnnxRuntime** - Base ONNX inference runtime
5. **Microsoft.ML.OnnxRuntime.DirectML** - Windows GPU acceleration
6. **SixLabors.ImageSharp** - Image manipulation (crop, resize, normalize)
7. **CommunityToolkit.Mvvm** - MVVM boilerplate reduction
8. **Microsoft.EntityFrameworkCore.Sqlite** - SQLite ORM provider
9. **Microsoft.Extensions.DependencyInjection** - DI container
10. **Microsoft.Extensions.Logging** - Logging abstractions
11. **Serilog** - Structured logging implementation

## Architecture Decisions

- **Clean Architecture**: Core (domain) -> Infrastructure (platform) -> App (UI)
- **Dependency Rule**: Source code dependencies flow inward only
- **Adapter Pattern**: IInferenceEngine abstracts GPU/CPU/NPU dispatch
- **MVVM Pattern**: ViewModels bind to Views via Avalonia data binding
- **Strategy Pattern**: Platform-specific implementations behind interfaces
- **Repository Pattern**: Data access abstraction for performer database
