using PerformerIdentifier.Core.Entities;

namespace PerformerIdentifier.Core.Interfaces;

/// <summary>
/// Defines the contract for face detection in images.
/// </summary>
public interface IFaceDetectionService
{
    /// <summary>
    /// Detects faces in the provided image data.
    /// </summary>
    /// <param name="imageData">Raw image bytes.</param>
    /// <param name="width">Image width in pixels.</param>
    /// <param name="height">Image height in pixels.</param>
    /// <param name="confidenceThreshold">Minimum confidence threshold (default 0.5).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A collection of detection results.</returns>
    Task<IReadOnlyList<DetectionResult>> DetectFacesAsync(
        byte[] imageData,
        int width,
        int height,
        float confidenceThreshold = 0.5f,
        CancellationToken cancellationToken = default);
}
