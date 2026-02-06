namespace PerformerIdentifier.Core.Interfaces;

/// <summary>
/// Defines the contract for extracting frames from video files.
/// </summary>
public interface IVideoFrameExtractor
{
    /// <summary>
    /// Extracts a single frame at the specified timestamp.
    /// </summary>
    /// <param name="videoPath">Path to the video file.</param>
    /// <param name="timestamp">Timestamp to extract the frame at.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Raw image bytes of the extracted frame.</returns>
    Task<byte[]> ExtractFrameAsync(
        string videoPath,
        TimeSpan timestamp,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets video metadata (duration, resolution, frame rate).
    /// </summary>
    /// <param name="videoPath">Path to the video file.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Video metadata.</returns>
    Task<VideoMetadata> GetMetadataAsync(
        string videoPath,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// Video file metadata.
/// </summary>
public record VideoMetadata(
    TimeSpan Duration,
    int Width,
    int Height,
    double FrameRate);
