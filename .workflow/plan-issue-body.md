# Performer Identifier - Complete Implementation

## Overview

The **Performer Identifier** is a cross-platform desktop application for privacy-conscious video analysis and face recognition. It runs entirely offline (Edge AI) using ONNX ML models -- RetinaFace/SCRFD for detection and ArcFace for recognition -- to scan video frames and identify specific individuals. Users can build a personal "Library of Performers" by tagging faces, with all data stored locally.

**Application Spec**: `plan_docs/Application Implementation Specification - Performer Identifier.md`
**Technical Design**: `plan_docs/Technical Design Document_ Cross-Platform Inference Application (2).md`
**Architecture**: `plan_docs/architecture.md`
**Tech Stack**: `plan_docs/tech-stack.md`

## Goals

- Provide offline, privacy-first face detection and recognition in video content
- Achieve >10 FPS inference on consumer hardware with GPU acceleration
- Support multiple video formats (MP4, AVI, MKV, MOV)
- Enable users to build and manage a persistent performer database
- Maintain cross-platform compatibility (Windows, macOS, Linux) via Avalonia UI
- Export analysis results to JSON

## Technology Stack

- **Language**: C# .NET 10.0
- **UI Framework**: Avalonia UI v11+ (cross-platform)
- **AI/Runtime**: ONNX Runtime v1.17+ (DirectML on Windows, CPU fallback elsewhere)
- **Architecture**: Clean Architecture (Core -> Infrastructure -> Presentation)
- **Databases/Storage**: SQLite with Entity Framework Core
- **Image Processing**: SixLabors.ImageSharp 3.1+
- **Video Engine**: FFmpeg (external CLI)
- **Logging/Observability**: Microsoft.Extensions.Logging + Serilog
- **Containerization/Infra**: Docker (future headless server), GitHub Actions CI/CD

## Application Features

- **Smart Video Player**: Integrated media player with transparent canvas overlay for real-time face detection bounding boxes
- **Face Detection Engine**: RetinaFace/SCRFD ONNX model with configurable confidence threshold
- **Face Recognition & Matching**: ArcFace 512-dimensional embeddings with cosine similarity matching
- **Performer Library Management**: SQLite-backed enrollment, persistence, and listing of performer face data
- **Adaptive Hardware Acceleration**: DirectML GPU first, CPU fallback via Strategy Pattern
- **Data Export**: JSON export of analysis reports (video filename, performer appearances, timestamps)
- **Batch Processing Queue**: Architecture designed to support future batch video processing

## System Architecture

### Core Services

1. **FaceDetectionService** -- ONNX-based face detection and bounding box extraction
2. **FaceRecognitionService** -- ArcFace embedding generation and cosine similarity matching
3. **VideoProcessorService** -- Orchestrates frame extraction, detection, recognition pipeline
4. **PerformerRepository** -- CRUD operations for performer embeddings in SQLite
5. **VideoFrameExtractor** -- FFmpeg integration for precise frame extraction

### Key Features (system-level)

- Platform-agnostic core with zero UI dependencies
- Runtime hardware detection and execution provider selection
- Non-blocking UI with background inference threads
- Cancellation support for long-running processing jobs

## Project Structure

```
PerformerIdentifier/
├─ src/
│  ├─ PerformerIdentifier.Core/          # Domain layer
│  │   ├─ Interfaces/                    # Service contracts
│  │   ├─ Entities/                      # Domain models
│  │   ├─ Services/                      # Business logic
│  │   └─ Data/                          # Database context
│  ├─ PerformerIdentifier.Windows/       # Infrastructure (DirectML + FFmpeg)
│  │   ├─ Services/
│  │   └─ Imaging/
│  └─ PerformerIdentifier.App/           # Avalonia UI
│     ├─ Views/
│     ├─ ViewModels/
│     └─ Assets/
├─ tests/
│  ├─ PerformerIdentifier.Tests/
│  └─ PerformerIdentifier.IntegrationTests/
├─ docs/
├─ scripts/
├─ docker/
└─ global.json
```

---

## Implementation Plan

### Phase 1: Foundation & Setup

- [ ] 1.1. Create .NET 10 solution with global.json SDK pinning
- [ ] 1.2. Create PerformerIdentifier.Core class library (net10.0)
- [ ] 1.3. Create PerformerIdentifier.Windows class library (net10.0)
- [ ] 1.4. Create PerformerIdentifier.App Avalonia application project
- [ ] 1.5. Create PerformerIdentifier.Tests xUnit test project
- [ ] 1.6. Create PerformerIdentifier.IntegrationTests xUnit test project
- [ ] 1.7. Configure project references and NuGet dependencies
- [ ] 1.8. Configure TreatWarningsAsErrors and XML documentation
- [ ] 1.9. Set up DI container in App startup
- [ ] 1.10. Create CI/CD build workflow (.github/workflows/build.yml)

### Phase 2: Core Engine (Detection + Recognition)

- [ ] 2.1. Define core interfaces
   - [ ] 2.1.1. IFaceDetectionService (detect faces, return bounding boxes)
   - [ ] 2.1.2. IFaceRecognitionService (generate embeddings, match)
   - [ ] 2.1.3. IVideoFrameExtractor (extract frames from video)
   - [ ] 2.1.4. IPerformerRepository (CRUD for performer data)
   - [ ] 2.1.5. IInferenceEngine (abstract ONNX execution)
- [ ] 2.2. Implement domain entities (Performer, DetectionResult, FaceEmbedding)
- [ ] 2.3. Implement FaceDetectionServiceBase with ONNX Runtime
- [ ] 2.4. Implement ArcFace recognition and cosine similarity matching
- [ ] 2.5. Implement VideoProcessorService (frame extraction + pipeline orchestration)
- [ ] 2.6. Implement PerformerDatabase with EF Core + SQLite
- [ ] 2.7. Implement WindowsImageData (DirectML tensor conversion)
- [ ] 2.8. Implement WindowsVideoFrameExtractor (FFmpeg wrapper)
- [ ] 2.9. Unit tests for all core services (mocked dependencies)

### Phase 3: UI/UX & Integration (Avalonia)

- [ ] 3.1. Create main window layout with Grid-based responsive design
- [ ] 3.2. Implement video playback control
- [ ] 3.3. Create transparent canvas overlay for bounding box rendering
- [ ] 3.4. Implement MainViewModel with CommunityToolkit.Mvvm
- [ ] 3.5. Wire up file picker for video import (MP4, AVI, MKV, MOV)
- [ ] 3.6. Implement performer library management UI (add, list, delete)
- [ ] 3.7. Connect inference pipeline to UI with progress reporting
- [ ] 3.8. Implement async operations with CancellationToken support
- [ ] 3.9. Settings/configuration panel (confidence threshold, GPU selection)

### Phase 4: Advanced Capabilities & Optimization

- [ ] 4.1. DirectML GPU acceleration tuning and FPS optimization
- [ ] 4.2. Non-blocking UI thread validation (background inference)
- [ ] 4.3. Error handling for corrupted videos, missing models, GPU failures
- [ ] 4.4. Memory management and leak prevention for long videos
- [ ] 4.5. JSON export of analysis results
- [ ] 4.6. Logging integration (Serilog + Microsoft.Extensions.Logging)
- [ ] 4.7. Performance profiling and bottleneck identification

### Phase 5: Testing, Docs, Packaging & Deployment

- [ ] 5.1. Complete unit test suite (target 80%+ coverage)
- [ ] 5.2. Integration tests for inference pipeline
- [ ] 5.3. End-to-end tests for video processing workflow
- [ ] 5.4. Comprehensive README with setup instructions
- [ ] 5.5. Developer guide (architecture, environment setup, model sourcing)
- [ ] 5.6. User guide (getting started, library management, troubleshooting)
- [ ] 5.7. Cross-platform packaging (Windows, macOS, Linux)
- [ ] 5.8. CI/CD pipeline with build, test, scan, publish stages
- [ ] 5.9. Docker support for future headless server mode
- [ ] 5.10. Final hardening and release checklist

---

## Mandatory Requirements Implementation

### Testing & Quality Assurance

- [ ] Unit tests -- coverage target: 80%+
- [ ] Integration tests (inference pipeline, database operations)
- [ ] E2E tests (video load -> detect -> recognize -> display)
- [ ] Performance tests (FPS benchmarks, memory usage)
- [ ] Automated tests in CI (GitHub Actions)

### Documentation & UX

- [ ] Comprehensive README
- [ ] User manual and feature docs
- [ ] XML docs on all public APIs
- [ ] Troubleshooting/FAQ
- [ ] Model acquisition guide

### Build & Distribution

- [ ] Build scripts (dotnet build, dotnet publish)
- [ ] Docker support for headless server (future)
- [ ] Cross-platform packaging (Avalonia publish profiles)
- [ ] Release pipeline

### Infrastructure & DevOps

- [ ] CI/CD workflows (build/test/scan/publish)
- [ ] TruffleHog secret scanning
- [ ] Static analysis configuration
- [ ] Performance benchmarking in CI

---

## Acceptance Criteria

- [ ] Core Clean Architecture implemented: Core has zero UI dependencies
- [ ] Face detection works end-to-end: video -> detect -> bounding boxes
- [ ] Face recognition works: embedding generation + cosine similarity matching
- [ ] Performer database persists across sessions (SQLite)
- [ ] Application runs cross-platform via Avalonia (Windows primary)
- [ ] GPU acceleration active on Windows (DirectML), CPU fallback works
- [ ] Inference exceeds 10 FPS on consumer hardware
- [ ] UI remains responsive during processing (non-blocking)
- [ ] Processing is cancellable without crashes
- [ ] JSON export produces valid analysis reports
- [ ] Test coverage target (80%+) met and CI green
- [ ] Documentation complete and accurate

## Risk Mitigation Strategies

| Risk | Mitigation |
|------|------------|
| ONNX model compatibility issues | Test models early in Phase 2; document exact versions |
| DirectML driver incompatibility | Implement CPU fallback via Strategy Pattern |
| FFmpeg not installed on target | Document FFmpeg requirement; detect and warn at startup |
| Avalonia video playback limitations | Research LibVLC or SkiaSharp-based alternatives early |
| Large video memory consumption | Stream frames instead of loading entire video; implement frame pooling |
| Cross-platform GPU support gaps | DirectML Windows-only; CoreML for macOS is future scope |
| Model accuracy on diverse faces | Document known limitations; allow user-configurable threshold |

## Timeline Estimate

- Phase 1: 1 week (Foundation & Setup)
- Phase 2: 2 weeks (Core Engine)
- Phase 3: 2 weeks (UI/UX & Integration)
- Phase 4: 1-2 weeks (Advanced & Optimization)
- Phase 5: 1-2 weeks (Testing, Docs, Packaging)
- **Total: 7-9 weeks**

## Success Metrics

- Processes MP4/AVI/MKV videos without crashes
- Detects faces with >90% accuracy for clear frontal angles
- Inference speed >10 FPS on GTX 1060 or better
- Database handles 100+ performers
- Application startup < 3 seconds
- UI remains responsive during all operations
- JSON export contains complete analysis data

## Repository Branch

Target branch for implementation: `dynamic-workflow-project-setup`

## Implementation Notes

- **UI Stack Change**: Original spec uses WinUI 3; replaced with Avalonia UI v11+ per stakeholder direction for cross-platform support
- **Clean Architecture**: Strict dependency rule ensures Core portability
- The PerformerIdentifier.Windows project retains DirectML-specific code
- Future: headless server mode via Docker (PerformerIdentifier.Core only)
